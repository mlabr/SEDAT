using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Json
{
	public class HitBatchBo : JsonBoBase
	{
		public HitBatchBo()
		{
			AppDataType = JsonBoDataType.HitBatch;
		}

		[JsonProperty("HitBatchList", Order = 3)]
		public List<HitBaseBo> BatchList = new List<HitBaseBo>();

	}
}
