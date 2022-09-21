using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KitDimFitness.BL.Model;

namespace KitDimFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя приложения.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Загрузить данные пользователя.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"> Файл не загружен.</exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: Что делать, если пользователя не прочитали
            }
        }

        /// <summary>
        /// Создание нового контроллера пользователя приложения.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            // TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height);

        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
