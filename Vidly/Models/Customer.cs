using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(60)]
            #endregion
        public string Name { get; set; }

        #region BirthdateValidation
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        #endregion
        public DateTime? Birthdate { get; set; } 

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        #region MembershipTypeIdValidation
        [Required]
        [Display(Name = "Membership Type")]
            #endregion
        public byte MembershipTypeId { get; set; }
    }
}   