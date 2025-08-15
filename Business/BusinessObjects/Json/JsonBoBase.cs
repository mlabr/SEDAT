using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Json
{
	public class JsonBoBase
	{
		[JsonProperty("Application", Order = 0)]
		public string Application { get; set; } = "SEDAT";

		[JsonProperty("Version", Order = 1)]
		public string AppVersion { get; set; } = string.Empty;

		[JsonProperty("DataType", Order = 2)]
		public string AppDataType { get; set; } = "";
	}
}
