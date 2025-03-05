using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.CodeList
{

    [Table("Caliber")]
    public class Caliber : EntityCodeBase
    {
        [PrimaryKey, AutoIncrement]
        public int? CaliberId { get; set; }


        public float? ValueMetric { get; set; }


    }
}
