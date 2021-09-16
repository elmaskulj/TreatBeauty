using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BaseUser> BaseUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Salon> Salons { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhotos { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCoupon> CustomerCoupons { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<BaseUserRole> BaseUserRoles { get; set; }
        public virtual DbSet<SalonServices> SalonServices { get; set; }
        public virtual DbSet<CustomerServiceRecommend> CustomerServiceRecommend { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6HS6GA4\\MSSQLSERVER_OLAP;Initial Catalog=TreatBeauty123;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            ////modelBuilder.Entity<Category>(entity =>
            ////{
            ////    entity.ToTable("Category");

            ////    entity.Property(e => e.Name)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);

            ////    entity.Property(e => e.Photo).HasColumnType("image");
            ////});

            ////modelBuilder.Entity<City>(entity =>
            ////{
            ////    entity.ToTable("City");

            ////    entity.Property(e => e.Name)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);
            ////});

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    //entity.ToTable("Employee");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.Email)
            //    //    .HasMaxLength(100)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.FirstName)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.LastName)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);



            //    //entity.Property(e => e.Photo).HasMaxLength(2000);

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.Employee)
            //        .HasForeignKey<Employee>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKEmployee769114");
            //});

            //modelBuilder.Entity<EmployeeRole>(entity =>
            //{
            //    //entity.ToTable("EmployeeRole");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.DateTimestamp).HasColumnName("Date timestamp");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.EmployeeRole)
            //        .HasForeignKey<EmployeeRole>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKEmployeeRo953673");

            //    entity.HasOne(d => d.Id1)
            //        .WithOne(p => p.EmployeeRole)
            //        .HasForeignKey<EmployeeRole>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKEmployeeRo515689");
            //});

            //modelBuilder.Entity<Grade>(entity =>
            //{
            //    //entity.ToTable("Grade");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.Date).HasColumnType("datetime");

            //    //entity.Property(e => e.Grade1).HasColumnName("Grade");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.Grade)
            //        .HasForeignKey<Grade>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKGrade670528");

            //    entity.HasOne(d => d.Id1)
            //        .WithOne(p => p.Grade)
            //        .HasForeignKey<Grade>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKGrade713375");
            //});

            //modelBuilder.Entity<News>(entity =>
            //{
            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            //    //entity.Property(e => e.Description)
            //    //    .HasMaxLength(255)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Photo).HasColumnType("image");

            //    //entity.Property(e => e.Title)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.News)
            //        .HasForeignKey<News>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKNews78680");
            //});

            ////modelBuilder.Entity<Role>(entity =>
            ////{
            ////    entity.ToTable("Role");

            ////    entity.Property(e => e.DescriptionVarchar).HasColumnName("Description varchar");

            ////    entity.Property(e => e.Name)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);
            ////});

            //modelBuilder.Entity<Salon>(entity =>
            //{
            //    //entity.ToTable("Salon");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            //    //entity.Property(e => e.Description)
            //    //    .HasMaxLength(255)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Location)
            //    //    .HasMaxLength(255)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Name)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Photo).HasColumnType("image");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.Salon)
            //        .HasForeignKey<Salon>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKSalon754735");
            //});

            //modelBuilder.Entity<Service>(entity =>
            //{
            //    //entity.ToTable("Service");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.Duration).HasColumnType("decimal(19, 0)");

            //    //entity.Property(e => e.Name)
            //    //    .HasMaxLength(50)
            //    //    .IsUnicode(false);

            //    //entity.Property(e => e.Photo).HasColumnType("image");

            //    //entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");

            //    entity.HasOne(d => d.Category)
            //        .WithOne(p => p.Service)
            //        .HasForeignKey<Service>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKService1322");
            //});

            //modelBuilder.Entity<ServicePhoto>(entity =>
            //{
            //    //entity.ToTable("ServicePhoto");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.Photo).HasColumnType("image");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.ServicePhoto)
            //        .HasForeignKey<ServicePhoto>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKServicePho973599");
            //});

            //modelBuilder.Entity<Term>(entity =>
            //{
            //    //entity.ToTable("Term");

            //    //entity.Property(e => e.Id).ValueGeneratedNever();

            //    //entity.Property(e => e.Date).HasColumnType("datetime");

            //    //entity.Property(e => e.EndTime).HasColumnType("datetime");

            //    //entity.Property(e => e.StartTime).HasColumnType("datetime");

            //    entity.HasOne(d => d.IdNavigation)
            //        .WithOne(p => p.Term)
            //        .HasForeignKey<Term>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKTerm722876");

            //    entity.HasOne(d => d.Id1)
            //        .WithOne(p => p.Term)
            //        .HasForeignKey<Term>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKTerm553516");

            //    entity.HasOne(d => d.Id2)
            //        .WithOne(p => p.Term)
            //        .HasForeignKey<Term>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKTerm253874");
            //});

            ////modelBuilder.Entity<User>(entity =>
            ////{
            ////    entity.ToTable("User");

            ////    entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            ////    entity.Property(e => e.Email)
            ////        .HasMaxLength(100)
            ////        .IsUnicode(false);

            ////    entity.Property(e => e.FirstName)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);

            ////    entity.Property(e => e.LastName)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);

            ////    entity.Property(e => e.PhoneNumber)
            ////        .HasMaxLength(50)
            ////        .IsUnicode(false);

            ////    entity.Property(e => e.Photo).HasMaxLength(1000);
            ////});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
