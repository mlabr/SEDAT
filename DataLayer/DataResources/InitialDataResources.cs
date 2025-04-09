using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;

namespace DataLayer.DataResources
{
    internal class InitialDataResources
    {

        public IEnumerable<CSightsType> GetCSightsTypeIEnumerable()
        {

			Tuple<string, string>[] sightses =
			{
				Tuple.Create("None", ""),
				Tuple.Create("Front only", ""),
				Tuple.Create("Open", ""),
				Tuple.Create("Aperture", ""),
				Tuple.Create("Collimator", ""),
				Tuple.Create("Scope", ""),
				Tuple.Create("Laser", ""),
				Tuple.Create("Other", "")
			};

			var i = 1;
			foreach (var sights in sightses)
			{
				var item = new CSightsType();
				item.Name = sights.Item1;
				item.Description = sights.Item2;
				item.CSightsTypeId = i;
				item.Priority = i;
				item.Note = "";
				i++;
				yield return item;
			}		
        }

		public IEnumerable<CFiringMode> GetCFiringModeIEnumerable()
		{
			Tuple<string, string>[] modes =
			{
				Tuple.Create("Not defined", "This is a default value."),
				Tuple.Create("Single shot", "A single-shot weapon requires the shooter to manually load a projectile, fire, and then manually reload after each shot."),
				Tuple.Create("Repeater", "A repeating weapon requires the shooter to manually operate a mechanism to prepare the weapon to fire again."),
				Tuple.Create("Self-loaded", "A self-loading weapon uses the energy from firing to automatically cycle the action, eject the spent case, chamber a new round, and reset for the next shot."),
				Tuple.Create("Fully automatic", "A fully automatic weapon continuously fires rounds as long as the trigger is held down, using the energy from each shot to cycle the action. Burst is also considered as fully automatic."),
				Tuple.Create("Other", "")

			};

			var i = 1;
			foreach (var mode in modes)
			{
				var item = new CFiringMode();
				item.Name = mode.Item1;
				item.Description = mode.Item2;
				item.CFiringModeId = i;
				item.Priority = i;
				item.Note = "";
				i++;
				yield return item;
			}
		}

		public IEnumerable<CShootingPosition> GetCShootingPositionIEnumerable()
		{
			string[] names = { "Not defined", "Prone", "Sitting", "Kneeling", "Standing", "Other", };

			var i = 1;
			foreach (string name in names)
			{
				var item = new CShootingPosition();
				item.CShootingPositionId = i;
				item.Name = name;
				item.Priority = i;
				item.Note = "";
				item.Description = "";
				i++;
				yield return item;
			}
		}


		public IEnumerable<CDisciplineType> GetCDisciplineTypeIEnumerable()
		{
			string[] names = { "Not defined", "Training", "Competition", "Other", };

			var i = 1;
			foreach (string name in names)
			{
				var item = new CDisciplineType();
				item.CDisciplineTypeId = i;
				item.Name = name;
				item.Priority = i;
				item.Note = "";
				item.Description = "";
				i++;
				yield return item;
			}
		}


		public IEnumerable<CPowerPrinciple> GetCPowerPrincipleIEnumerable()
		{
			var tier0 = new List<CategoryList>();

			tier0.Add(new CategoryList("Not set"));
			var mechanical = new CategoryList("Mechanical");
			tier0.Add(mechanical);

			var airgung = new CategoryList("Airgun");
			tier0.Add(airgung);

			var springer = new CategoryList("Springer");
			springer.SubCategoryList.Add(new CategoryList("Metal spring"));
			springer.SubCategoryList.Add(new CategoryList("Gas spring"));
			springer.SubCategoryList.Add(new CategoryList("Recoilless"));
			airgung.SubCategoryList.Add(springer);

			var precharged = new CategoryList("Precharded");
			precharged.SubCategoryList.Add(new CategoryList("PCA"));
			precharged.SubCategoryList.Add(new CategoryList("PCP"));
			precharged.SubCategoryList.Add(new CategoryList("CO2"));
			precharged.SubCategoryList.Add(new CategoryList("Airsoft gas"));
			airgung.SubCategoryList.Add(precharged);
			airgung.SubCategoryList.Add(new CategoryList("Blow"));

			var firearm = new CategoryList("Firearm");
			tier0.Add(firearm);
			var muzzleLoader = new CategoryList("Muzzleloader");
			muzzleLoader.SubCategoryList.Add(new CategoryList("MatchLock"));
			muzzleLoader.SubCategoryList.Add(new CategoryList("FlintLock"));
			muzzleLoader.SubCategoryList.Add(new CategoryList("Percussion"));
			muzzleLoader.SubCategoryList.Add(new CategoryList("Inline"));
			firearm.SubCategoryList.Add(muzzleLoader);
			var cartridge = new CategoryList("Cartridge");
			cartridge.SubCategoryList.Add(new CategoryList("Rimfire"));
			cartridge.SubCategoryList.Add(new CategoryList("Centerfire"));
			cartridge.SubCategoryList.Add(new CategoryList("Lefaucheux"));
			cartridge.SubCategoryList.Add(new CategoryList("Dreyse"));
			firearm.SubCategoryList.Add(cartridge);
			firearm.SubCategoryList.Add(new CategoryList("Caseless"));

			tier0.Add(new CategoryList("Laser"));
			tier0.Add(new CategoryList("Electromagnetic"));
			tier0.Add(new CategoryList("Rocket"));
			var current = 1;


			var cpowerList = new List<CPowerPrinciple>();
			foreach (var item in tier0)
			{
				cpowerList.Add( new CPowerPrinciple
				{
					Name = item.Name,
					CPowerPrincipleId = current,
					CPowerPrincipleParrentId = current
				});

				int t1 = current;
				current++;
				foreach (var sub in item.SubCategoryList)
				{
					cpowerList.Add(new CPowerPrinciple
					{
						Name = sub.Name,
						CPowerPrincipleId = current,
						CPowerPrincipleParrentId = t1
					});
					int t2 = current;
					current++;

					foreach (var ssub in sub.SubCategoryList)
					{
						cpowerList.Add(new CPowerPrinciple
						{
							Name = ssub.Name,
							CPowerPrincipleId = current,
							CPowerPrincipleParrentId = t2
						});
						current++;
					}
				}
			}



			var stop = 0;


			var i = 1;
			foreach (var item in cpowerList)
			{
				item.Priority = i;
				item.IsUsed = true;
				i++;

				yield return item;
			}


			//return list;// as IEnumerable<CPowerPrinciple>;
		}


		public IEnumerable<CWeaponType> GetCWeaponTypeIEnumerable()
		{
			var tier0 = new List<CategoryList>();

			tier0.Add(new CategoryList("Not set"));

			var handgun = new CategoryList("Handgun");
			handgun.SubCategoryList.Add(new CategoryList("Pistol"));
			handgun.SubCategoryList.Add(new CategoryList("Revolver"));
			handgun.SubCategoryList.Add(new CategoryList("Derringer"));
			tier0.Add(handgun);

			var longgun = new CategoryList("Long gun");
			longgun.SubCategoryList.Add(new CategoryList("Carbine"));
			longgun.SubCategoryList.Add(new CategoryList("Rifle"));
			longgun.SubCategoryList.Add(new CategoryList("Bullpup"));
			longgun.SubCategoryList.Add(new CategoryList("Submachachine gun"));
			longgun.SubCategoryList.Add(new CategoryList("Machine gun"));
			tier0.Add(longgun);

			var bow = new CategoryList("Bow");
			bow.SubCategoryList.Add(new CategoryList("Long"));
			bow.SubCategoryList.Add(new CategoryList("Recurve"));
			bow.SubCategoryList.Add(new CategoryList("Compound"));
			tier0.Add(bow);

			var crossbow = new CategoryList("Crossbow");
			crossbow.SubCategoryList.Add(new CategoryList("Pistol"));
			crossbow.SubCategoryList.Add(new CategoryList("Medieval"));
			crossbow.SubCategoryList.Add(new CategoryList("Recurve"));
			crossbow.SubCategoryList.Add(new CategoryList("Compound"));
			crossbow.SubCategoryList.Add(new CategoryList("Reverse limb"));
			tier0.Add(crossbow);

			tier0.Add(new CategoryList("Other"));

			var current = 1;

			var cTypeList = new List<CWeaponType>();
			foreach (var item in tier0)
			{
				cTypeList.Add(new CWeaponType
				{
					Name = item.Name,
					CWeaponTypeId = current,
					CWeaponTypeParrentId = current
				});

				int t1 = current;
				current++;
				foreach (var sub in item.SubCategoryList)
				{
					cTypeList.Add(new CWeaponType
					{
						Name = sub.Name,
						CWeaponTypeId = current,
						CWeaponTypeParrentId = t1
					});
					int t2 = current;
					current++;

					//foreach (var ssub in sub.SubCategoryList)
					//{
					//	cpowerList.Add(new CPowerPrinciple
					//	{
					//		Name = ssub.Name,
					//		CPowerPrincipleId = current,
					//		CPowerPrincipleParrentId = t2
					//	});
					//	current++;
					//}
				}
			}



			var stop = 0;


			var i = 1;
			foreach (var item in cTypeList)
			{
				item.Priority = i;
				item.IsUsed = true;
				i++;

				yield return item;
			}


			//return list;// as IEnumerable<CPowerPrinciple>;
		}

		public Person GetDefaultPerson()
		{
			var person = new Person();
			person.PersonId = 1;
			person.Nickname = "Unknown";
			person.IsUsed = true;

			return person;
		}

		internal Target GetDefaultTarget()
		{
			var target = new Target();
			target.TargetId = 1;
			target.Name = "Unknown";
			target.IsUsed = true;

			return target;
		}

		internal Weapon GetDefaultWeapon()
		{
			var weapon = new Weapon();
			weapon.WeaponId = 1;
			weapon.Name = "Unknown";
			weapon.PersonId = 1;
			weapon.IsUsed = true;

			return weapon;
		}

		internal WeaponProfile GetDefaultWeaponProfile()
		{
			var wp = new WeaponProfile();
			wp.WeaponProfileId = 1;
			wp.WeaponId = 1;
			wp.Name = "Unknown";
			wp.CWeaponTypeId = 1;
			wp.CPowerPrincipleId = 1;
			wp.CFiringModeId = 1;

			return wp;
		}


		internal Sights GetDefaultSights()
		{
			var sights = new Sights();
			sights.SightsId = 1;
			sights.CSightsTypeId = 1;
			sights.Description = "This are a default sights";
			sights.Name = "Unknown";
			sights.IsUsed = true;

			return sights;

		}

		internal ProfileSights GetDefaultProfileSights()
		{
			var ps = new ProfileSights();
			ps.ProfileSightsId = 1;
			ps.SightsId= 1;
			ps.WeaponProfileId = 1;

			return ps;
		}

		internal Munition GetDefaultMunition()
		{
			var munition = new Munition();
			munition.MunitionId = 1;
			munition.Name = "Unknown";
			munition.Description = "This is default munition";
			munition.CaliberId = 1;
			munition.IsUsed = true;

			return munition;
		}

		internal Caliber GetDefaultCCaliber()
		{
			var ccaliber = new Caliber();
			ccaliber.CaliberId = 1;
			ccaliber.Name = "Unknown";
			ccaliber.Description = "This is default caliber.";
			ccaliber.Priority = 1;
			ccaliber.IsUsed = true;
			return ccaliber;
		}

		internal ProfileCaliber GetDefaultProfileCaliber()
		{
			var pc = new ProfileCaliber();
			pc.ProfileCCaliberId = 1;
			pc.WeaponProfileId = 1;
			pc.CaliberId = 1;
			return pc;
		}
		internal Series GetDefaultSeries()
		{
			var group = new Series();
			group.SeriesId = 1;
			group.Name = "Not set";
			group.IsUsed = true;
			return group;
		}

		internal SeriesSession GetDefaultSessionEvent()
		{
			throw new NotImplementedException();
		}

		internal object GetDefaultPlace()
		{
			var place = new Place();
			place.PlaceId = 1;
			place.Name = "Unknown";
			place.IsUsed = true;
	
			return place;
		}


	}
}
