using System;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;



namespace api.Repositorys
{
	public class BuchungRepository : IBuchungService
	{
		private readonly BuchungDbContext _buchungRepository;

        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-!?§%&ß";

        public BuchungRepository(BuchungDbContext buchungRepository)
		{
			_buchungRepository = buchungRepository;
		}

        public async Task<Buchung> createBuchung(Buchung buchung)
        {

            string getVerifyCode = GenerateRandomCode(32);

            buchung.verifyCode = getVerifyCode;

			var addBuchung = await _buchungRepository.buchung.AddAsync(buchung);
			await _buchungRepository.SaveChangesAsync();
			return addBuchung.Entity;

        }

        public static string GenerateRandomCode(int lenght)
        {

            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < lenght; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }


        
    }
}

