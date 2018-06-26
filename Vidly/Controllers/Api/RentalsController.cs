using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IEnumerable<RentalDto> Index()
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.ReturnedDate == null)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return rentals;
        }

        [HttpPut]
        public IHttpActionResult CheckIn(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var rentalInDb = _context.Rentals.SingleOrDefault();

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


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
