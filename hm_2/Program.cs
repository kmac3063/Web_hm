using System;

namespace hm_2
{
    public class Program
    {
        const int REQ_ADMIN = 1;
        const int REQ_MODERATOR = 2;
        const int REQ_CLIENT = 3;
        const int REQ_WORKER = 4;
        const int REQ_LOOKER = 5;
        const int REQ_EXIT = 6;
        const int REQ_MANAGE_MODERATOR = 7;
        const int REQ_MANAGE_REQ_AND_OF = 8;
        const int REQ_GO_BACK = 9;
        //const int REQ_EXIT = 6;
        //const int REQ_EXIT = 6;

        static void read_request(ref int request)
        {
            Console.WriteLine("\n\nОт чьего лица действовать: ");
            Console.WriteLine("1. Глав.админ");
            Console.WriteLine("2. Модератор");
            Console.WriteLine("3. Заказчик");
            Console.WriteLine("4. Исполнитель");
            Console.WriteLine("5. Просто смотрю");
            Console.WriteLine("6. Выйти");
            Console.Write("\nВведите номер: ");

            request = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите имя админа: ");
            var adm_name = Console.ReadLine();

            freelanceExchange freelanceExchange = new freelanceExchange(adm_name);

            var request = 0;
            while (request != REQ_EXIT)
            {
                read_request(ref request);
                switch (request)
                {
                    case REQ_ADMIN:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ АДМИН");
                            Console.WriteLine("------------------------------\n");
                            while (request != REQ_GO_BACK)
                            {
                                switch (read_admin_request())
                                {
                                    case REQ_LOOKER:
                                        lookInfo(freelanceExchange, "ADMIN");
                                        break;
                                    case REQ_MANAGE_MODERATOR:
                                        manage_moderator(freelanceExchange);
                                        break;
                                    case REQ_MANAGE_REQ_AND_OF:
                                        manage_request_and_offers(freelanceExchange);
                                        break;
                                    default:
                                        request = REQ_GO_BACK;
                                        break;
                                }
                            }
                            
                            break;
                        }
                    case REQ_MODERATOR:
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
                    case REQ_CLIENT:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ЗАКАЗЧИК");
                            Console.WriteLine("------------------------------\n");
                            //Посмотреть любой список
                            //Выбрать заявку
                            //Добавить заявку
                            break;
                        }
                    case REQ_WORKER:
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
