using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class SessionBo
	{

		public int PlaceId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public string Note { get; set; }

        public DateTime DateStart { get; set; }

		public DateTime DateEnd { get; set; }

        public bool IsUsed { get; set; } = true;

		private string _errorMessageDate = "Start date cannot be after end date.";

		private string _errorMessageName = "Name cannot be empty";


		public bool IsValid()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return false;
			}

			if (DateStart > DateEnd)
			{
				return false;
			}

			return true;
		}

		public string GetErrorMessageName()
		{
			if(string.IsNullOrEmpty(Name))
			{
				return _errorMessageName;
			}

			return string.Empty;
		}

		public string GetErrorMessageDate()
		{
			if (DateStart > DateEnd)
			{
				return _errorMessageDate;
			}

			return string.Empty;
		}




    }

}
