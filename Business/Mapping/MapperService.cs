using AutoMapper;
using Business.BusinessObjects.CodeList;
using DataLayer.Entities.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
	public class MapperService
	{
		private readonly IMapper _mapper;

		public MapperService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public CSightsBo CSightToCSightsBo(CSights sights)
		{
			//CSights -> CSightsBo
			return _mapper.Map<CSightsBo>(sights);
		}
	}
}
