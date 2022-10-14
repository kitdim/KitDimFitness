using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace KitDimFitness.BL.Controller
{
    public abstract class ControllerBase<T> where T : class
    {
        protected IDataSaver<T> manager = new SerializeDataSaver<T>();
        protected void Save(T item)
        {
            manager.Save(item);
        }
        protected List<T> Load()
        {
            return manager.Load();
        }
    }
}
