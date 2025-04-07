using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataResources;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;

namespace DataLayer
{
	public class DbHelper
	{
        public string ConnectionString { get; private set; } = "testDb.db";


		public void CreateDatabase(string connectionString)
		{
			Console.WriteLine("New database initializing.");
			using (var db = new SQLiteConnection(connectionString))
			{


				var idr = new InitialDataResources();
				//Indenpendece Tables
				db.CreateTable<Caliber>();
				db.Insert(idr.GetDefaultCCaliber());

				db.CreateTable<CSightsType>();
				foreach (var s in idr.GetCSightsTypeIEnumerable())
				{
					db.Insert(s);
				}

				db.CreateTable<CShootingPosition>();
				foreach (var s in idr.GetCShootingPositionIEnumerable())
				{
					db.Insert(s);
				}


				db.CreateTable<CDisciplineType>();
				foreach (var s in idr.GetCDisciplineTypeIEnumerable())
				{
					db.Insert(s);
				}

				db.CreateTable<CFiringMode>();
				foreach (var s in idr.GetCFiringModeIEnumerable())
				{
					db.Insert(s);
				}

				db.CreateTable<Person>();
				db.Insert(idr.GetDefaultPerson());

				db.CreateTable<Place>();
				db.Insert(idr.GetDefaultPlace());


				db.CreateTable<Target>();
				db.Insert(idr.GetDefaultTarget());

				//db.CreateTable<Weapon>(); //This shit doesnt work :(
				//Tables with foreign key msut be created this way.
				db.Execute("Create Table Weapon (WeaponId INTEGER PRIMARY KEY NOT NULL UNIQUE," +
												"Name String NOT NULL," +
												"Identification String," +
												"Note String," +
												"PersonId INTEGER References Person (PersonId) NOT NULL," +
												"IsUsed Boolean NOT NULL );");
				db.Insert(idr.GetDefaultWeapon());

				db.Execute("Create Table Sights (SightsId INTEGER PRIMARY KEY NOT NULL," +
												"Name String NOT NULL," +
												"CSightsTypeId INTEGER References CSightsType (CSightsTypeId) NOT NULL," +
												"Description String," +
												"Note String," +
												"IsUsed Boolean NOT NULL );");

				db.Insert(idr.GetDefaultSights());


				db.Execute("Create Table Munition (MunitionId INTEGER PRIMARY KEY NOT NULL," +
												"CaliberId INTEGER References Caliber (CaliberId) NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Note String," +
												"IsUsed Boolean NOT NULL );");
				db.Insert(idr.GetDefaultMunition());


				db.CreateTable<Series>();
				db.Insert(idr.GetDefaultSeries());


				db.CreateTable<Session>();


				db.Execute("Create Table SeriesSession (SeriesSessionId INTEGER PRIMARY KEY NOT NULL," +
												"SeriesId INTEGER References Series (SeriesId) NOT NULL," +
												"SessionId INTEGER References Session (SessionId) NOT NULL );");


				db.Execute("Create Table CPowerPrinciple (CPowerPrincipleId INTEGER PRIMARY KEY NOT NULL," +
												"CPowerPrincipleParrentId INTEGER References CPowerPrinciple (CPowerPrincipleId) NOT NULL," +
												"Priority INTEGER NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Note String," +
												"IsUsed Boolean NOT NULL );");


				foreach (var item in idr.GetCPowerPrincipleIEnumerable())
				{
					db.Insert(item);
				}

				//db.Insert(idr.GetCPowerPrincipleIEnumerable());

				db.Execute("Create Table Discipline (DisciplineId INTEGER PRIMARY KEY NOT NULL," +
												"SessionId INTEGER References Session (SessionId) NOT NULL," +
												"CDisciplineId INTEGER References CDiscipline (CDisciplineId) NOT NULL," +
												"CShootingPositionId INTEGER References CShootingPosition (CShootingPositionId) NOT NULL," +
												"TargetId INTEGER References Target (TargetId) NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Range DECIMAL NOT NULL," +
												"IsRangeMetric Boolean NOT NULL," +
												"ScoreMax DECIMAL NOT NULL," +
												"ShotsMax DECIMAL NOT NULL," +
												"Date bigint," +
												"TimeStart," +
												"TimeEnd," +
												"Note String" +
												" );" +
												"");



				db.Execute("Create Table CWeaponType (CWeaponTypeId INTEGER PRIMARY KEY NOT NULL," +
												"CWeaponTypeParrentId INTEGER References CWeaponType (CWeaponTypeId) NOT NULL," +
												"Priority INTEGER NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Note String," +
												"IsUsed Boolean NOT NULL );");

				foreach (var item in idr.GetCWeaponTypeIEnumerable())
				{
					db.Insert(item);
				}


				db.Execute("Create Table WeaponProfile (WeaponProfileId INTEGER PRIMARY KEY NOT NULL," +
												"WeaponId INTEGER References Weapon (WeaponId)  NOT NULL," +
												"CWeaponTypeId INTEGER References CWeaponType (CWeaponTypeId)  NOT NULL," +
												"CPowerPrincipleId INTEGER References CPowerPrinciple (CPowerPrincipleId)  NOT NULL," +
												"CFiringModeId INTEGER References CFiringMode (CFiringModeId)  NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Note String," +
												"MaintenanceLastDate TEXT," +
												"MaintenanceIntervalDate INTEGER NOT NULL ," +
												"MaintenanceIntervalShots INTEGER NOT NULL ," +
												"IsUsed Boolean NOT NULL );");


				//TODO insert default weapon
				//
				db.Insert(idr.GetDefaultWeaponProfile());

				db.Execute("Create Table ProfileCaliber (ProfileCaliberId INTEGER PRIMARY KEY NOT NULL," +
												"WeaponProfileId INTEGER References WeaponProfile (WeaponProfileId) NOT NULL," +
												"CaliberId INTEGER References Caliber (CaliberId) NOT NULL);");

				db.Insert(idr.GetDefaultProfileCaliber());

				db.Execute("Create Table ProfileSights (ProfileSightsId INTEGER PRIMARY KEY NOT NULL," +
												"WeaponProfileId INTEGER References WeaponProfile (WeaponProfileId) NOT NULL," +
												"SightsId INTEGER References Sights (SightsId) NOT NULL);");

				db.Insert(idr.GetDefaultProfileSights());

				db.Execute("Create Table Record (RecordId INTEGER PRIMARY KEY NOT NULL," +
												"DisciplineId INTEGER References Discipline (DisciplineId) NOT NULL," +
												"PersonId INTEGER References Person (PersonId) NOT NULL," +
												"WeaponProfileId INTEGER References WeaponProfile (WeaponProfileId) NOT NULL," +
												"MunitionId INTEGER References Munition (MunitionId) NOT NULL," +
												"SightsId INTEGER References Sights (SightsId) NOT NULL," +
												"Score INTEGER NOT NULL," +
												"ShotsCount INTEGER NOT NULL," +
												"TimeStart," +
												"TimeEnd," +
												"Data" +
												"Note"+
												"IsUsed Boolean NOT NULL );");


				Console.WriteLine("Done");
			}
		}
	}
}
