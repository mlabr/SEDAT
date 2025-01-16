using SQLite;

namespace DataLayer.Entities.CodeList
{
	[Table("CPowerPrinciple")]
	public class CPowerPrinciple : EntityCodeBase
	{
        [PrimaryKey]
        public int CPowerPrincipleId { get; set; }
	
		public int CPowerPrincipleParrentId {  get; set; }
    }
}
