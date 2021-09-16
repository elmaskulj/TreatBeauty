using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Filters;
using Microsoft.EntityFrameworkCore;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Enumerations;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Services
{
    public class BaseUserService : IBaseUserService
    {
        private readonly MyContext _context;
        protected readonly IMapper _mapper;
        protected readonly IMailService _mailService;

        public BaseUserService(MyContext _context, IMapper _mapper, IMailService _mailService)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._mailService = _mailService;
        }
        public Model.BaseUser GetById(int id)
        {
            var entity = _context.BaseUsers.Find(id);

            return _mapper.Map<Model.BaseUser>(entity);
        }
        public Model.BaseUser Insert(BaseUserInsertRequest request/*, int userRole = ((int)Enumerations.UserRole.Customer)*/)
        {
            var entity = _mapper.Map<Database.BaseUser>(request);
            _context.Add(entity);

            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException("Lozinka se razlikuje od potvrde");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            entity.CreatedAt = DateTime.Now;

            _context.SaveChanges();

            Database.BaseUserRole baseUserRole = new Database.BaseUserRole();
            baseUserRole.BaseUserId = entity.Id;
            baseUserRole.RoleId = request.RoleId;

            _context.BaseUserRoles.Add(baseUserRole);

            _context.SaveChanges();

            if (request.RoleId == (int)UserRole.Employee)
            {
                string message = "<h1>TreatBeauty account</h1>" +
                                "<h3>Pristupni podaci za account na platformi TreatBeauty su: </h3>" +
                                "<h4>Email: <strong>" + request.Email + "</strong><br/>  Lozinka: <strong> " + request.Password + "  </strong></h4>";
                _mailService.SendEmailAsync(request.Email, "Novi account", message);
                //_mailService.SendEmailAsync(request.Email, "New Account", "<h1>Hey!," +
                //    " new Login to your account noticed.</h1>"
                //    + "<h2>Your password is : " + "</h2>" + "<strong>" +
                //    request.Password + "</strong>" +
                //    "<p> New login to your account at " + DateTime.Now + "</p>");
            }
            return _mapper.Map<Model.BaseUser>(entity);
        }
        public Model.BaseUser Update(int Id, BaseUserInsertRequest request)
        {
            var set = _context.Set<BaseUser>();
            var entity = set.Find(Id);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.BaseUser>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public async Task<Model.BaseUser> Login(string email, string password)
        {
            try
            {
                var entity = await _context.BaseUsers.Include("BaseUserRoles.Role").FirstOrDefaultAsync(x => x.Email == email);

                if (entity == null)
                {
                    throw new UserException("Pogrešan username ili password");
                }
                var hash = GenerateHash(entity.PasswordSalt, password);

                if (hash != entity.PasswordHash)
                {
                    throw new UserException("Pogrešan username ili password");
                }

                return _mapper.Map<Model.BaseUser>(entity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<Model.BaseUser> GetAll()
        {
            var query = _context.BaseUsers.AsQueryable();

            var entities = query.ToList();
            return _mapper.Map<IEnumerable<Model.BaseUser>>(entities);
        }
        public Model.BaseUser Register(BaseUserInsertRequest request)
        {
            var entity = _mapper.Map<Database.BaseUser>(request);
            _context.Add(entity);

            entity.isActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _mailService.SendEmailAsync(request.Email, "New Account", "<h1>Hey!, new Login to your account noticed.</h1>" +
                "<h2>Your password is : " + "</h2>" + "<strong>" + request.Password + "</strong>" +
                "<p> New login to your account at " + DateTime.Now + "</p>");

            _context.SaveChanges();

            _context.Customers.Add(new Customer { Id = entity.Id });

            Database.BaseUserRole baseUserRole = new Database.BaseUserRole();
            baseUserRole.BaseUserId = entity.Id;
            baseUserRole.RoleId = request.RoleId;

            _context.BaseUserRoles.Add(baseUserRole);

            _context.SaveChanges();

            return _mapper.Map<Model.BaseUser>(entity);
        }
    }
}
