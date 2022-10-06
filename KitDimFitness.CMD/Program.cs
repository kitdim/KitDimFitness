using System;
using System.Globalization;
using System.Resources;
using KitDimFitness.BL.Controller;
using KitDimFitness.BL.Model;

namespace KitDimFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("KitDimFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello"), culture);

            Console.Write(resourceManager.GetString("EnterName"), culture);
            var name = Console.ReadLine();
                       
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDataTime("дату рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
            while (true)
            {


                Console.WriteLine("Что вы ходите сделать?");
                Console.WriteLine("E - ввести прием пищи.");
                Console.WriteLine("A - ввести упражнение.");
                Console.WriteLine("Q - выход.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();

                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static(DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Ввведите название упражнения:");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту:");

            var begin = ParseDataTime("начало упражения");
            var end = ParseDataTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var callories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, callories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDataTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}

