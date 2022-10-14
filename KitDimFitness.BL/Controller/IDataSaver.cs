using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitDimFitness.BL.Controller
{
    public interface IDataSaver<T> where T : class
    {
        void Save(T item);
        List<T> Load();
    }
}
