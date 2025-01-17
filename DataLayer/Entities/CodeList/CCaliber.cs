using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.CodeList
{

    [Table("CCaliber")]
    public class CCaliber : EntityCodeBase
    {
        [PrimaryKey]
        public int? CCaliberId { get; set; }


        public float? ValueMetric { get; set; }


    }
}
