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
        [Display(Name = "Nome")]
        #endregion
        public string Name { get; set; }

        #region ReleasedDateValidation
        [Required]
        [Display(Name = "Data de Lançamento")]
        #endregion
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        #region StockValidation
        [Required]
        [Range(1, 20)]
        [Display(Name = "Número em estoque")]
        #endregion
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        #region GenreValidation
        [Required]
        [Display(Name = "Gênero")]
        #endregion
        public byte GenreId { get; set; }

    }

}