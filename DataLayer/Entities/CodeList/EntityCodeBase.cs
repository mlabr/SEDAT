using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.CodeList
{
    public abstract class EntityCodeBase
    {
        [StringLength(256), NotNull]
        public string Name { get; set; }

        [NotNull]
        public int Priority { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [NotNull]
        public bool IsUsed { get; set; } = true;

    }
}
