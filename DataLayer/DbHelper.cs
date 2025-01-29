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
				db.CreateTable<CCaliber>();
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


				db.CreateTable<CDiscipline>();
				foreach (var s in idr.GetCDisciplineIEnumerable())
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
												"CCaliberId INTEGER References CCaliber (CCaliberId) NOT NULL," +
												"Name String NOT NULL," +
												"Description String," +
												"Note String," +
												"IsUsed Boolean NOT NULL );");
				db.Insert(idr.GetDefaultMunition());


				db.CreateTable<Event>();
				db.Insert(idr.GetDefaultEvent());


				db.CreateTable<Session>();


				//TODO after session
				//db.Execute("Create Table SessionEvent (SessionEventId INTEGER PRIMARY KEY NOT NULL," +
				//								"EventId References Event (EventdId) NOT NULL," +
				//								"SessionId References Session (SessionId) NOT NULL," +
				//								"Name String NOT NULL," +
				//								"Note String," +
				//								"IsUsed Boolean NOT NULL );");

				//db.Insert(idr.GetDefaultSessionEvent());


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
												"Range DECIMAL," +
												"ScoreMax DECIMAL," +
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
												"IsUsed Boolean NOT NULL );");


				db.Execute("Create Table ProfileCCaliber (ProfileCCaliberId INTEGER PRIMARY KEY NOT NULL," +
												"WeaponProfileId INTEGER References Weapon (WeaponId) NOT NULL," +
												"CCcaliberId INTEGER References CCaliber (CCaliberId) NOT NULL);");



				db.Execute("Create Table ProfileSights (ProfileSightsId INTEGER PRIMARY KEY NOT NULL," +
												"WeaponProfileId INTEGER References WeaponProfile (WeaponProfileId) NOT NULL," +
												"SightsId INTEGER References Sights (SightsId) NOT NULL);");

				Console.WriteLine("Done");
			}
		}
	}
}
