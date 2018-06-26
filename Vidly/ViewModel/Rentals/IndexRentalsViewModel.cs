using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModel.Rentals
{
    public class IndexRentalsViewModel
    {
        public int Id { get; set; }

        [Required]
        public IndexCustomersViewModel Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime RentedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }
    }
}