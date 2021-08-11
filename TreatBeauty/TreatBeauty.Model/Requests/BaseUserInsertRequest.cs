using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class BaseUserInsertRequest
    {
        //[Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        //[Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        //[Required(AllowEmptyStrings = false)]
        //[EmailAddress()]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //[Required(AllowEmptyStrings = false)]
        //[MinLength(4)]
        public string Password { get; set; }
        //[Required(AllowEmptyStrings = false)]
        //[MinLength(4)]
        public string ConfirmPassword { get; set; }
        public bool? isActive { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
