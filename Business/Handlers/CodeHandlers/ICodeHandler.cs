using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.CodeHandlers
{
	public interface ICodeHandler <T>
	{

		public List<T> GetAllList();


		public List<T> GetUsedOnlyList();
	}
}
