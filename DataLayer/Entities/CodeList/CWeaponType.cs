using SQLite;

namespace DataLayer.Entities.CodeList
{
    [Table("CWeaponType")]
	public class CWeaponType : EntityCodeBase
	{
        [PrimaryKey]
        public int CWeaponTypeId { get; set; }

        public int CWeaponTypeParrentId { get; set; }

    }
}
