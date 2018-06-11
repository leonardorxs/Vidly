using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        #region NameValidation
        [Required]
        [StringLength(100)]
        #endregion
        public string Name { get; set; }

        #region ReleasedDateValidation
        [Required]
        [Display(Name = "Release Date")]
        #endregion
        public DateTime? ReleasedDate { get; set; }

        #region StockValidation
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        #endregion
        public int? Stock { get; set; }

        #region GenreValidation
        [Required]
        [Display(Name = "Genre")]
        #endregion
        public byte? GenreId { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}