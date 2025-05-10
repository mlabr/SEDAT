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
			# region Entities to Bo 
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

			internal static CSightsTypeBo CSightsTypeToCSightsTypeBo(CSightsType item)
			{
				var bo = new CSightsTypeBo();
				bo.DbId = item.CSightsTypeId;
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



			#endregion

			#region Bo to Entities
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

			#endregion

		}
	}
}
