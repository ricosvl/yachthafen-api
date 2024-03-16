using System;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Repositorys
{
	public class BuchungRepository : IBuchungService
	{
		private readonly BuchungDbContext _buchungRepository;

		public BuchungRepository(BuchungDbContext buchungRepository)
		{
			_buchungRepository = buchungRepository;
		}

        public async Task<Buchung> createBuchung(Buchung buchung)
        {

			var addBuchung = await _buchungRepository.buchung.AddAsync(buchung);
			await _buchungRepository.SaveChangesAsync();
			return addBuchung.Entity;

          
        }
    }
}

