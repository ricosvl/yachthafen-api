using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuchungController : ControllerBase
    {
       private readonly IBuchungService _buchungRepository;

        public BuchungController(IBuchungService buchungRepository)
        {
            _buchungRepository = buchungRepository;
        }

           [HttpPost("register")]
        public async Task<IActionResult> addUser(Buchung buchung)
        {
            var res = await _buchungRepository.createBuchung(buchung);
            return Ok(res);
        }

    }
}
