﻿//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace commenergy.Models.Models
//{
   

//        public class ApplicationUser : IdentityUser
//        {
//            [Required]
//            public string FirstName { get; set; }

//            [Required]
//            public string LastName { get; set; }

//            [Required]
//            public string Email { get; set; }
        
  
//        [Key]
//        public override string Id { get; set; }
           
//        public string UserId { get; set; }


//        [Required, DataType(DataType.Password)]
//        public virtual String Password { get; set; }

//        [DataType(DataType.MultilineText)]
//        public virtual String Comment { get; set; }

//        public virtual Boolean IsApproved { get; set; }
//        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
//        public virtual DateTime? LastPasswordFailureDate { get; set; }
//        public virtual DateTime? LastActivityDate { get; set; }
//        public virtual DateTime? LastLockoutDate { get; set; }
//        public virtual DateTime? LastLoginDate { get; set; }
//        public virtual String ConfirmationToken { get; set; }
//        public virtual DateTime? CreateDate { get; set; }
//        public virtual Boolean IsLockedOut { get; set; }
//        public virtual DateTime? LastPasswordChangedDate { get; set; }
//        public virtual String PasswordVerificationToken { get; set; }
//        public virtual DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        
//        public virtual List<Article> Articles { get; set; }
//    }
//}
