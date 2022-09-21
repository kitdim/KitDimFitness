using System;
using KitDimFitness.BL.Controller;

namespace KitDimFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение KitDimFitness");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var birthDate = DateTime.Parse(Console.ReadLine()); // TODO: периписать на TryParse

            Console.Write("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}

