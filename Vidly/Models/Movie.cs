using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(100)]
        #endregion
        public string Name { get; set; }

        #region ReleasedDateValidation
        [Required]
        [Display(Name = "Release Date")]
        #endregion
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        #region StockValidation
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        #endregion
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        #region GenreValidation
        [Required]
        [Display(Name = "Genre")]
        #endregion
        public byte GenreId { get; set; }

    }

}