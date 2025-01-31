using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
	internal static partial class Mapper
	{
		internal static PersonBo PersonToPersonBo(Person item)
		{
			var bo = new PersonBo();
			bo.Id = item.PersonId;
			bo.NickName = item.Nickname;
			bo.FirstName = item.Firstame;
			bo.LastName = item.Surname;
			bo.Note = item.Note;
			bo.IsUsed = item.IsUsed;

			return bo;
		}

	}
}
