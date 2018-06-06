using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(100)]
        #endregion
        public string Name { get; set; }

        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        #region StockValidation
        [Required]
        [Range(1, 20)]
        #endregion
        public int Stock { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}