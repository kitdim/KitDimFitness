using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace KitDimFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new SerializeDataSaver();

        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);
        }
        
        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }
    }
}
