using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitDimFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Callories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double proteins, double fats, double carbohyds, double callories)
        {
            // TODO: ПРОВЕРКА

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohyds / 100.0;
            Callories = callories / 100.0;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
