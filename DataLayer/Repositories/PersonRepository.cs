using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class PersonRepository
	{
		DbHelper helper;
		private string connectionString;

		public PersonRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public PersonRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public Person Get(int id)
		{
			throw new NotImplementedException();
		}


		public List<Person> GetAll() 
		{ 
			throw new NotImplementedException();
		}

		public List<Person> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from person in conn.Table<Person>()
						   where person.IsUsed == true
						   select person;

				return list.ToList();
			}
		}

	}
}
