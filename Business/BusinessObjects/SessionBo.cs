using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class SessionBo
	{
		public SessionBo()
		{
			SeriesBoList = new List<SeriesBo>();
			DisciplineBoList = new List<DisciplineBo>();
		}

		public int PlaceId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public string Note { get; set; }

        public DateTimeOffset DateStart { get; set; }

		public DateTimeOffset DateEnd { get; set; }

		public List<SeriesBo> SeriesBoList { get; set; }

		public List<DisciplineBo> DisciplineBoList { get; set; }

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
