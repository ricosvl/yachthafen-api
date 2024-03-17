using System;
namespace api.Models
{
	public class Buchung
	{
		public int id { get; set; }

		public string firstname { get; set; }

		public string lastname { get; set; }

		public string email { get; set; }

		public DateTime startDate { get; set; }

		public DateTime endDate { get; set; }

		public string anliegePlatz { get; set; }

        public string verifyCode { get; set; }

    }
}

