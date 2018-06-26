using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(60)]
        [Display(Name = "Nome")]
        #endregion
        public string Name { get; set; }

        #region BirthdateValidation
        [Display(Name = "Data Nascimento")]
        [Min18YearsIfAMember]
        #endregion
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        #region MembershipTypeIdValidation
        [Required]
        [Display(Name = "Plano")]
        #endregion
        public byte MembershipTypeId { get; set; }
    }
}