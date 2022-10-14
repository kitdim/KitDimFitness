﻿using System;
using System.Runtime.Serialization.Formatters.Binary;
using KitDimFitness.BL.Model;

namespace KitDimFitness.BL.Controller
{
    public class EatingController :ControllerBase<Eating>
    {
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private const string FOOD_FILE_NAME = "foods.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.",nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load().First();
        }

        private List<Food> GetAllFoods()
        {
            return Load();
        }
        private void Save()
        {
            Save();
        }
    }
}
