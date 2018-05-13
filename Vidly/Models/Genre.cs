using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(255)]
            #endregion
        public string Name { get; set; }
    }
}