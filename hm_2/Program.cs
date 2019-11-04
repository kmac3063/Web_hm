using System;

namespace hm_2
{
    public class Program
    {
        const int REQ_Admin = 1;
        const int REQ_Moderator = 2;
        const int REQ_Client = 3;
        const int REQ_Worker = 4;
        const int REQ_LOOKER = 5;
        const int REQ_EXIT = 6;

        const int REQ_MANAGE_Moderator = 7;
        const int REQ_MANAGE_REQ_AND_OF = 8;
        const int REQ_GO_BACK = 9;
        //const int REQ_EXIT = 6;
        //const int REQ_EXIT = 6;

        static void read_request(ref int request, string status)
        {
            switch (status)
            {
                case ("base"):
                    Console.WriteLine("\n\nОт чьего лица действовать: ");
                    Console.WriteLine("1. Глав.админ");
                    Console.WriteLine("2. Модератор");
                    Console.WriteLine("3. Заказчик");
                    Console.WriteLine("4. Исполнитель");
                    Console.WriteLine("5. Просто смотрю");
                    Console.WriteLine("6. Выйти");
                    Console.Write("\nВведите номер: ");
                    break;
                case ("admin"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Посмотреть список модераторов");
                    Console.WriteLine("2. Добавить модератора");
                    Console.WriteLine("3. Удалить модератора");
                    Console.WriteLine("4. Посмотреть список фрилансеров");
                    Console.WriteLine("5. Посмотреть список заказчиков");
                    Console.WriteLine("6. Посмотреть список заявлений(поиск клиента)");
                    Console.WriteLine("7. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("8. Посмотреть список заявлений(поиск исполнителя)");
                    Console.WriteLine("9. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("10. Посмотреть имя админа");
                    Console.WriteLine("11. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("moderator"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Посмотреть список модераторов");
                    Console.WriteLine("2. Посмотреть список фрилансеров");
                    Console.WriteLine("3. Посмотреть список заказчиков");
                    Console.WriteLine("4. Посмотреть список заявлений(поиск клиента)");
                    Console.WriteLine("5. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("6. Посмотреть список заявлений(поиск исполнителя)");
                    Console.WriteLine("7. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("8. Посмотреть имя админа");
                    Console.WriteLine("9. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("client"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Добавить заявление(поиск исполнителя)");
                    Console.WriteLine("2. Посмотреть список заявлений(поиск исполнителя)");
                    Console.WriteLine("3. Удалить своё заявление(поиск исполнителя");
                    Console.WriteLine("4. Посмотреть список фрилансеров");
                    Console.WriteLine("5. Выбрать услугу фрилансера");
                    Console.WriteLine("6. Посмотреть имя админа");
                    Console.WriteLine("7. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("worker"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Добавить заявление(поиск заказчика)");
                    Console.WriteLine("2. Посмотреть список заявлений(поиск заказчика)");
                    Console.WriteLine("3. Удалить своё заявление(поиск заказчика");
                    Console.WriteLine("4. Посмотреть список заказчиков");
                    Console.WriteLine("5. Выполнить запрос заказчика");
                    Console.WriteLine("6. Посмотреть имя админа");
                    Console.WriteLine("7. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("look"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Посмотреть список фрилансеров");
                    Console.WriteLine("2. Посмотреть список заказчиков");
                    Console.WriteLine("3. Посмотреть имя админа");
                    Console.WriteLine("4. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
            }
            
            request = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n");
        }

        void read_Admin_request() //TO DO
        {
            

            //request = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите имя админа: ");
            Admin admin = new Admin(Console.ReadLine());

            Moderator moderator = new Moderator("Миша");

            People people = new People("Серёжа");
            Client client = new Client("Снежана");
            Worker worker = new Worker("Игорь");

            FreelanceExchange FreelanceExchange = new FreelanceExchange(admin);

            var request = 0;
            while (request != REQ_EXIT)
            {

                read_request(ref request, "base");
                switch (request)
                {
                    case REQ_Admin:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ АДМИН");
                            Console.WriteLine("------------------------------\n");
                            while (request != REQ_GO_BACK)
                            {
                                read_request(ref request, "admin");
                                switch (request)
                                {
                                    case (1):
                                        //admin.
                                        break;
                                }
                            }
                            
                            break;
                        }
                    case REQ_Moderator:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ МОДЕРАТОР");
                            Console.WriteLine("------------------------------\n");
                            //Посмотреть любой список
                            //Назначить модератора
                            //Добавить заявку
                            //Удалить заявку
                            //Удалить жанр
                            break;
                        }
                    case REQ_Client:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ЗАКАЗЧИК");
                            Console.WriteLine("------------------------------\n");
                            //Посмотреть любой список
                            //Выбрать заявку
                            //Добавить заявку
                            break;
                        }
                    case REQ_Worker:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ФРИЛАНСЕР");
                            Console.WriteLine("------------------------------\n");
                            //Посмотреть любой список
                            //Назначить модератора
                            //Добавить предложение
                            break;
                        }
                    case REQ_LOOKER:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ЗАШЛИ ПРОСТО ПОЛЮБОВАТЬСЯ");
                            Console.WriteLine("------------------------------\n");
                            //Посмотреть список исполнителей
                            //Посмотреть список предлагаемых работ
                            //Посмотреть свой баланс
                            //Просмотреть категории
                            //Зайти в категорию
                            break;
                        }
                    case REQ_EXIT:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("СПАСИБО ЗА ПОСЕЩЕНИЕ!");
                            Console.WriteLine("------------------------------\n");
                            continue;
                        }
                }
            }
        }
    }
}
