using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok();
        }

        //POST
        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                 
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    RentedDate = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
