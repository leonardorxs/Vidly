using System;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public CustomerRentalDto Customer { get; set; }
        public MovieRentalDto Movie { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}