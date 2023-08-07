namespace LessonRepo
{
    public class Lesson
    {
        public string LessonName { get; set; }
        public bool HasLesson { get; set; }
        public int LessonNumber { get; set; }
        public int ClassroomNumber { get; set; }

        public Lesson(string name, int lessonNumber, int classroomNumber)
        {
            LessonName = name;
            HasLesson = false;
            LessonNumber = lessonNumber;
            ClassroomNumber = classroomNumber;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Lesson> lessons = new List<Lesson>();

            // Добавляем 7 экземпляров класса Lesson с указанием номера урока и кабинета
            lessons.Add(new Lesson("Биология", 1, 52));
            lessons.Add(new Lesson("Англиский", 2, 50));
            lessons.Add(new Lesson("Физкультура", 3, 3));
            lessons.Add(new Lesson("Польский", 4, 50));
            lessons.Add(new Lesson("География", 5, 46));
            lessons.Add(new Lesson("Математика", 6, 57));
            lessons.Add(new Lesson("История", 7, 26));

            // Запрашиваем у пользователя информацию о посещении уроков
            for (int i = 0; i < lessons.Count; i++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write($"Вы были на уроке '{lessons[i].LessonName}' (Урок : {lessons[i].LessonNumber}, Кабинет : {lessons[i].ClassroomNumber})? (Введите '1' если да, '2' если нет): ");
                    string userInput = Console.ReadLine();

                    if (userInput.Trim() == "1")
                    {
                        lessons[i].HasLesson = true;
                        validInput = true;
                    }
                    else if (userInput.Trim() == "2")
                    {
                        lessons[i].HasLesson = false;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите '1' или '2'.");
                    }
                }
            }

            // Проверяем, были ли на всех уроках
            bool attendedAllLessons = true;
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"Урок '{lesson.LessonName}' (Урок : {lesson.LessonNumber}, Кабинет : {lesson.ClassroomNumber}) был проведен: {lesson.HasLesson}");

                if (!lesson.HasLesson)
                {
                    attendedAllLessons = false;
                }
            }

            if (attendedAllLessons)
            {
                Console.WriteLine("Вы были на всех уроках!");
            }
        }
    }
}