using KitDimFitness.BL.Model;
using System;

namespace KitDimFitness.BL.Controller
{
    class DatabaseDataSaver<T> : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }        
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
