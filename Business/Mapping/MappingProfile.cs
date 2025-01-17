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
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CSights, CSightsTypeBo>();

			CreateMap<CSightsTypeBo, CSights>();
		}
	}
}
