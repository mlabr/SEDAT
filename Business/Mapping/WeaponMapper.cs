using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;

namespace Business.Mapping
{
	internal static partial class Mapper
	{
		internal static class Weapon
		{


			internal static CaliberBo CaliberToCaliberBo(Caliber item)
			{
				var bo = new CaliberBo();
				bo.DbId = item.CaliberId.Value;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}

			internal static Caliber CaliberBoToCCaliber(CaliberBo bo)
			{
				var cal = new Caliber();
				cal.CaliberId = null;
				if (bo.IsExisting)
				{
					cal.CaliberId = bo.DbId;
				}
				cal.Name = bo.Name;
				cal.Description = bo.Description;
				cal.Note = bo.Note;
				cal.IsUsed = true;
				cal.Priority = bo.Priority;

				return cal;
			}
			internal static CFiringModeBo CFiringModeToCFiringModeBo(CFiringMode item)
			{
				var bo = new CFiringModeBo();
				bo.DbId = item.CFiringModeId;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}

			internal static CPowerPrincipleBo CPowerPrincipleToCPowerPrincipleBo(CPowerPrinciple item)
			{
				var bo = new CPowerPrincipleBo();
				bo.DbId = item.CPowerPrincipleId;
				bo.ParentDbId = item.CPowerPrincipleParrentId;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}

			internal static CSightsTypeBo CSightToCSightsBo(CSightsType csight)
			{
				var bo = new CSightsTypeBo();
				bo.DbId = csight.CSightsTypeId.Value;
				bo.Name = csight.Name;
				bo.Description = csight.Description;
				bo.Note = csight.Note;
				bo.IsUsed = csight.IsUsed;
				return bo;
			}

			internal static CSightsType CSightsTypeBoToCSightsType(SightsBo bo)
			{
				var sights = new CSightsType();
				sights.CSightsTypeId = null;
				if (bo.IsExisting)
				{
					sights.CSightsTypeId = bo.DbId;
				}
				sights.Name = bo.Name;
				sights.Description = bo.Description;
				sights.Note = bo.Note;
				sights.IsUsed = true;
				sights.CSightsTypeId = bo.CSightsType.DbId;

				return sights;
			}

			internal static CSightsTypeBo CSightsTypeToCSightsTypeBo(CSightsType item)
			{
				var bo = new CSightsTypeBo();
				bo.DbId = item.CSightsTypeId.Value;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}

			internal static CWeaponTypeBo CWeaponTypeToCWeaponTypeBo(CWeaponType item)
			{
				var bo = new CWeaponTypeBo();
				bo.DbId = item.CWeaponTypeId;
				bo.ParentDbId = item.CWeaponTypeParrentId;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}
			internal static Munition MunitionBoToMunition(MunitionBo item)
			{
				var m = new Munition();
				m.CaliberId = item.DbId;
				m.Name = item.Name;
				m.CaliberId = item.CaliberId;
				m.Description = item.Description;
				m.Note = item.Note;

				return m;
			}

			internal static MunitionBo MunitionToMunitionBo(Munition item)
			{
				var m = new MunitionBo();
				m.Name = item.Name;
				m.CaliberId = item.CaliberId;
				m.Description = item.Description;
				m.Note = item.Note;

				return m;
			}

			internal static Sights SightsBoToSights(SightsBo bo)
			{
				var sights = new Sights();
				sights.SightsId = null;
				if (bo.IsExisting)
				{
					sights.SightsId = bo.DbId;
				}
				sights.Name = bo.Name;
				sights.Description = bo.Description;
				sights.Note = bo.Note;
				sights.IsUsed = true;
				sights.CSightsTypeId = bo.CSightsType.DbId;

				return sights;
			}

			internal static SightsBo SightsToSightsBo(Sights item)
			{
				var bo = new SightsBo();
				bo.DbId = item.SightsId.Value;
				bo.Name = item.Name;
				bo.Description = item.Description;
				bo.Note = item.Note;
				bo.IsUsed = item.IsUsed;

				return bo;
			}


		}
	}
}
