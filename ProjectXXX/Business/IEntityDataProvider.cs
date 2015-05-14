using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEntityDataProvider<T>
    {
        IList<T> GetAllElements();

        T GetElementById();

        void AddElement(T element);

        void DeleteElement(string id);

        void UpdateElement(string id);
    }
}
