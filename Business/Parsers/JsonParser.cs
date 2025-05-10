using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Parsers
{
	public static class JsonParser
	{


		public static WeaponBo ConvertToWeaponBo(string json)
		{
			if (json == null)
			{
				return null; //or throw exception?
			}
			WeaponBo bo;


			using (JsonDocument doc = JsonDocument.Parse(json))
			{
				bo = new WeaponBo();
				// Ruční výběr jednotlivých uzlů
				JsonElement root = doc.RootElement.GetProperty("WeaponProfile");
				bo.WeaponName = root.GetProperty("WeaponBase").GetProperty("Name").GetString();
				bo.ProfileName = root.GetProperty("Name").GetString();
				bo.CWeaponTypeCode = root.GetProperty("CWeaponTypeId").GetInt32();
				bo.CPowerPrincipleCode = root.GetProperty("CPowerPrincipleId").GetInt32();
				bo.CFiringModeCode = root.GetProperty("CFiringModeId").GetInt32();

				bo.Description = root.GetProperty("Description").GetString();
				bo.Note = root.GetProperty("WeaponBase").GetProperty("Note").GetString();
				var sights = new SightsBo();
				sights.Name = root.GetProperty("Sights").GetProperty("Name").GetString();
				sights.CSightsType.DbId = root.GetProperty("Sights").GetProperty("CSightsType").GetInt32();
				sights.Description = root.GetProperty("Sights").GetProperty("Description").GetString();
				sights.Note = root.GetProperty("Sights").GetProperty("Note").GetString();

				bo.SightsBoList = new List<SightsBo>();
				bo.SightsBoList.Add(sights);

				var caliber = new CaliberBo();
				caliber.Name = root.GetProperty("Caliber").GetProperty("Name").GetString();
				caliber.Description = root.GetProperty("Caliber").GetProperty("Description").GetString();
				caliber.Note = root.GetProperty("Caliber").GetProperty("Note").GetString();
				bo.CCaliberBoList = new List<CaliberBo>();
				bo.CCaliberBoList.Add(caliber);
			}

			
			return bo;
		}
	}
}
