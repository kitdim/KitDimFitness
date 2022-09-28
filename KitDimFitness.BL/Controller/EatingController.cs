using System;
using System.Runtime.Serialization.Formatters.Binary;
using KitDimFitness.BL.Model;

namespace KitDimFitness.BL.Controller
{
    public class EatingController
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.",nameof(user));
            Foods = GetAllFoods();
        }

        private List<Food> GetAllFoods()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
                {
                    return foods;
                }
                else
                {
                    return new List<Food>();
                }
            }
        }
    }
}
