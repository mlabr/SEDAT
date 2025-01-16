using DataLayer.Entities.CodeList;

namespace DataLayer.Interfaces
{
	public interface ICodeRepository<T>
	{
		T Get(int id);

		List<T> GetAllList();

		public List<T> GetUsedOnlyList();

		void Insert(T item);

		public void Update(T item);

		void InsertList(List<T> item);

	}
}
