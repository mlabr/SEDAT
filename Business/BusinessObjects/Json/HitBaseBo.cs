using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Json
{
	public class HitBaseBo
	{
		[JsonProperty("Order")]
		public int Order { get; set; }

		[JsonProperty("Score")]
		public decimal Score { get; set; }

		[JsonProperty("XCount")]
		public int XCount { get; set; }

		[JsonProperty("ShotsCount")]
		public int ShotsCount { get; set; }
	}
}
