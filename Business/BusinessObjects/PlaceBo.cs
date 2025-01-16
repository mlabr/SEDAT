using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class PlaceBo
	{
		public int PlaceId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Note { get; set; }

		public bool IsUsed { get; set; }	



		private string _errorMessageName = "Name cannot be empty";

		public bool IsValid()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return false;
			}

			return true;
		}

		public string GetErrorMessageName()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return _errorMessageName;
			}

			return string.Empty;
		}

	}
}
