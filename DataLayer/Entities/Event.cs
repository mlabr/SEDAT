﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Event : EntityBase
	{
		[PrimaryKey, AutoIncrement]
        public int EventId { get; set; }

		public string Name { get; set; }
    }
}
