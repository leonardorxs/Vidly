using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(255)]
        #endregion
        public string Name { get; set; }

        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        #region StockValidation
        [Required]
        [Range(0, int.MaxValue)]
        #endregion
        public int Stock { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

    }

}