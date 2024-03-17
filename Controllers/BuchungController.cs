using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuchungController : ControllerBase
    {
       private readonly IBuchungService _buchungRepository;
        private readonly BuchungDbContext _buchungDbContext;

        public BuchungController(IBuchungService buchungRepository, BuchungDbContext buchungDbContext)
        {
            _buchungRepository = buchungRepository;
            _buchungDbContext = buchungDbContext;
        }

        [HttpPost("createBookings")]
        public async Task<IActionResult> addUser(Buchung buchung)
        {
            var res = await _buchungRepository.createBuchung(buchung);
            return Ok(res);
        }

        [HttpGet("getAllBookings")]
        public async Task<IActionResult> getAllBookings()
        {
            try
            {
                var bookings = await _buchungDbContext.buchung.ToListAsync();

                return Ok(bookings);

            } catch(Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> deleteUSer(int id)
        {
            try
            {
                var booking = await _buchungRepository.deleteBooking(id);
                return Ok(booking);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }
        }

    }
}
