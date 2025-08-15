using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Json
{
	internal class JsonBase
	{
		public string Application { get; set; } = "SEDAT";

		public string Version { get; set; } = string.Empty;

		public string DataType {  get; set; } = string.Empty;
	}
}
