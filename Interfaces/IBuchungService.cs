using System;
using api.Models;

namespace api.Interfaces
{
	public interface IBuchungService
	{
        Task<Buchung> createBuchung(Buchung buchung);
    }
}

