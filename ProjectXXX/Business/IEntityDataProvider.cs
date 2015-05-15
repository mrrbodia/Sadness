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

        T GetElementById(string id);

        void AddElement(T element);

        void DeleteElement(T element);

        void UpdateElement(T element);
    }
}
