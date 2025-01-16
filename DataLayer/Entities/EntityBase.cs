using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class EntityBase
	{
        public string Note { get; set; }

        [NotNull]
        public bool IsUsed { get; set; } = true;
    }
}
