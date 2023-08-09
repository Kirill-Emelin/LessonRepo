namespace LessonRepo
{
    public class Lesson
    {
        /// <summary>
        /// Название урока. Используется для хранения имени урока.
        /// </summary>
        public string LessonName { get; set; }
        /// <summary>
        ///  Показатель наличия урока. Значение "true" указывает на посещение урока, "false" - на отсутствие.
        /// </summary>
        public bool HasLesson { get; set; }
        /// <summary>
        /// Номер урока. Используется для идентификации порядка урока в расписании.
        /// </summary>
        public int LessonNumber { get; set; }
        /// <summary>
        /// Номер кабинета. Сохраняет информацию о номере кабинета, в котором проходит урок.
        /// </summary>
        public int ClassroomNumber { get; set; }

        // Конструктор класса Lesson
        public Lesson(string name, int lessonNumber, int classroomNumber)
        {
            LessonName = name;
            HasLesson = false; // По умолчанию урок не посещен
            LessonNumber = lessonNumber;
            ClassroomNumber = classroomNumber;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Lesson> lessons = new List<Lesson>();

            // Создание экземпляров уроков и добавление их в список
            lessons.Add(new Lesson("Биология", 1, 52));
            lessons.Add(new Lesson("Англиский", 2, 50));
            lessons.Add(new Lesson("Физкультура", 3, 3));
            lessons.Add(new Lesson("Польский", 4, 50));
            lessons.Add(new Lesson("География", 5, 46));
            lessons.Add(new Lesson("Математика", 6, 57));
            lessons.Add(new Lesson("История", 7, 26));

            // Запрос информации о посещении уроков у пользователя
            for (int i = 0; i < lessons.Count; i++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write($"Вы были на уроке '{lessons[i].LessonName}' (Урок : {lessons[i].LessonNumber}, Кабинет : {lessons[i].ClassroomNumber})? (Введите '1' если да, '2' если нет): ");
                    string userInput = Console.ReadLine();

                    if (userInput.Trim() == "1")
                    {
                        lessons[i].HasLesson = true; // Пользователь посетил урок
                        validInput = true; // Валидный ввод завершен
                    }
                    else if (userInput.Trim() == "2")
                    {
                        lessons[i].HasLesson = false; // Пользователь не посетил урок
                        validInput = true; // Валидный ввод завершен
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите '1' или '2'.");
                    }
                }
            }

            // Проверка и вывод информации о посещении каждого урока
            bool attendedAllLessons = true;
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"Урок '{lesson.LessonName}' (Урок : {lesson.LessonNumber}, Кабинет : {lesson.ClassroomNumber}) был проведен: {lesson.HasLesson}");

                if (!lesson.HasLesson)
                {
                    attendedAllLessons = false;
                }
            }

            // Вывод сообщения о посещении всех уроков
            if (attendedAllLessons)
            {
                Console.WriteLine("Вы были на всех уроках!");
            }
        }
    }
}