using System;
using System.Collections.Generic;
using System.Text;

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
        const int REQ_GO_BACK = 9;
        const int REQ_BAD = 10;

        static bool read_request(ref int request, string status)
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
                    Console.WriteLine("4. Посмотреть список предложений");
                    Console.WriteLine("5. Посмотреть список заказчиков");
                    Console.WriteLine("6. Увидеть список заявлений(поиск клиента)");
                    Console.WriteLine("7. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("8. Увидеть список заявлений(поиск исполнителя)");
                    Console.WriteLine("9. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("10. Посмотреть имя админа");
                    Console.WriteLine("11. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("moderator"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Посмотреть список модераторов");
                    Console.WriteLine("2. Посмотреть список предложений");
                    Console.WriteLine("3. Посмотреть список заказчиков");
                    Console.WriteLine("4. Увидеть список заявлений(поиск клиента)");
                    Console.WriteLine("5. Одобрить заявление(поиск клиента)");
                    Console.WriteLine("6. Увидеть список заявлений(поиск исполнителя)");
                    Console.WriteLine("7. Одобрить заявление(поиск исполнителя)");
                    Console.WriteLine("8. Посмотреть имя админа");
                    Console.WriteLine("9. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("client"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Добавить заявление(поиск исполнителя)");
                    Console.WriteLine("2. Увидеть список заявлений(поиск исполнителя)");
                    Console.WriteLine("3. Удалить своё заявление с рассмотрения(поиск исполнителя");
                    Console.WriteLine("4. Посмотреть список предложений");
                    Console.WriteLine("5. Выбрать услугу фрилансера");
                    Console.WriteLine("6. Посмотреть имя админа");
                    Console.WriteLine("7. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("worker"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Добавить заявление(поиск заказчика)");
                    Console.WriteLine("2. Увидеть список заявлений(поиск заказчика)");
                    Console.WriteLine("3. Удалить своё заявление(поиск заказчика");
                    Console.WriteLine("4. Посмотреть список заказчиков");
                    Console.WriteLine("5. Выполнить запрос заказчика");
                    Console.WriteLine("6. Посмотреть имя админа");
                    Console.WriteLine("7. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                case ("look"):
                    Console.WriteLine("\n\nЧто вы хотите сделать?: ");
                    Console.WriteLine("1. Посмотреть список предложений");
                    Console.WriteLine("2. Посмотреть список заказчиков");
                    Console.WriteLine("3. Посмотреть имя админа");
                    Console.WriteLine("4. Выйти");

                    Console.Write("\nВведите номер: ");
                    break;
                    
            }
            try
            {
                request = Int32.Parse(Console.ReadLine());
            }
            catch
            { 
                Console.WriteLine("Введены неверные данные!");
                return false;
            }
            Console.WriteLine("\n");
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите имя админа: ");
            Admin admin = new Admin(Console.ReadLine());
            FreelanceExchange freelanceExchange = new FreelanceExchange(admin);

            People people = new People("Серёжа");

            Client client = new Client("Снежана");
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Jeff", "Хочу сосисок", "100 тенге" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Loma", "Хочу сайт, где фон будет зеркальным, чтоб пользователь видел своё отражение", "3000 рублей" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Kalop", "Нужна игра, как ГТА5, только лучше и в каждое здание можно войти", "200 рублей в неделю" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Monarch100_200", "Нужно починить мангал", "5 юаней" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Чука", "Хочу того", "100p" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Гека", "Хочу сего", "200p" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Шука", "Хочу туда", "600p" });
            client.tryAddRequest(ref freelanceExchange, new List<string> { "Мука", "Хочу сюда", "700p" });

            Worker worker = new Worker("Игорь");
            worker.tryAddOffer(ref freelanceExchange, new List<string> { "Рома", "Могу принести сосисок", "10 единиц дерева и 2 единицы еды" });
            worker.tryAddOffer(ref freelanceExchange, new List<string> { "Игорь", "Верстаю сайты", "5 рублей символ" });
            worker.tryAddOffer(ref freelanceExchange, new List<string> { "Диня", "Взламываю странички вконтакте", "100 рублей предоплата" });
            worker.tryAddOffer(ref freelanceExchange, new List<string> { "Поля", "Рисую пиксель арты", "Поесть, попить" });
            worker.tryAddOffer(ref freelanceExchange, new List<string> { "Толя", "Настройка комьютера", "300$" });

            Moderator moderator = new Moderator("Миша");
            Moderator moderator1 = new Moderator("Jija");
            Moderator moderator2 = new Moderator("KOLOVRAT WOWCIRCLE 3.3.5");
            admin.addModerator(ref freelanceExchange, moderator);
            admin.addModerator(ref freelanceExchange, moderator1);
            admin.addModerator(ref freelanceExchange, moderator2);
            moderator.addOffer(ref freelanceExchange, 0);
            moderator.addOffer(ref freelanceExchange, 0);
            moderator.addRequest(ref freelanceExchange, 2);
            moderator.addRequest(ref freelanceExchange, 2);

            var request = 0;
            while (request != REQ_EXIT)
            {
                while (!read_request(ref request, "base")) { };
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
                                        freelanceExchange.showModeratorList();
                                        break;
                                    case (2):
                                        Console.Write("Введите имя нового модератора: ");
                                        Moderator mod = new Moderator(Console.ReadLine());
                                        admin.addModerator(ref freelanceExchange, mod);
                                        Console.WriteLine($"Модератор {mod.getName()} добавлен!");
                                        break;
                                    case (3):
                                        Console.Write("Введите id удаляемого модератора: ");
                                        admin.delModerator(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        Console.WriteLine("Модератор удалён!");
                                        break;
                                    case (4):
                                        freelanceExchange.showListOfOffers();
                                        break;
                                    case (5):
                                        freelanceExchange.showListOfRequests();
                                        break;
                                    case (6):
                                        freelanceExchange.showWaitListOfOffers();
                                        break;
                                    case (7):
                                        Console.Write("Введите id одобряемого заявления: ");
                                        try
                                        {
                                            admin.addOffer(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление одобрено!");
                                        break;
                                    case (8):
                                        freelanceExchange.showWaitListOfRequests();
                                        break;
                                    case (9):
                                        Console.Write("Введите id одобряемого заявления: ");
                                        try
                                        {
                                            admin.addRequest(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление одобрено!");
                                        break;
                                    case (10):
                                        Console.WriteLine($"Имя админа: {admin.getName()}");
                                        break;
                                    case (11):
                                        request = REQ_GO_BACK;
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
                            while (request != REQ_GO_BACK)
                            {
                                read_request(ref request, "moderator");
                                switch (request)
                                {
                                    case (1):
                                        freelanceExchange.showModeratorList();
                                        break;
                                    case (2):
                                        freelanceExchange.showListOfOffers();
                                        break;
                                    case (3):
                                        freelanceExchange.showListOfRequests();
                                        break;
                                    case (4):
                                        freelanceExchange.showWaitListOfOffers();
                                        break;
                                    case (5):
                                        Console.Write("Введите id одобряемого заявления: ");
                                        try
                                        {
                                            moderator.addOffer(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление одобрено!");
                                        break;
                                    case (6):
                                        freelanceExchange.showWaitListOfRequests();
                                        break;
                                    case (7):
                                        Console.Write("Введите id одобряемого заявления: ");
                                        try
                                        {
                                            moderator.addRequest(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление одобрено!");
                                        break;
                                    case (8):
                                        Console.WriteLine($"Имя админа: {admin.getName()}");
                                        break;
                                    case (9):
                                        request = REQ_GO_BACK;
                                        break;
                                }
                            }
                            break;
                        }
                    case REQ_Client:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ЗАКАЗЧИК");
                            Console.WriteLine("------------------------------\n");
                            while (request != REQ_GO_BACK)
                            {
                                read_request(ref request, "client");
                                switch (request)
                                {
                                    case (1):
                                        var t = new List<string>();
                                        Console.Write("От какого имени заявление?: ");
                                        t.Add(Console.ReadLine());
                                        Console.Write("Введите вашу просьбу, с которой вы обратились: ");
                                        t.Add(Console.ReadLine());
                                        Console.Write("Сколько вы готовы отдать за это?: ");
                                        t.Add(Console.ReadLine());
                                        client.tryAddRequest(ref freelanceExchange, t);
                                        Console.WriteLine("Ваше заявление отправлено на рассмотрение!");
                                        break;
                                    case (2):
                                        freelanceExchange.showWaitListOfRequests();
                                        break;
                                    case (3):
                                        Console.Write("Введите id вашего заявления, которое хотите удалить: ");
                                        try
                                        {
                                            client.delRequest(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление удалено!");
                                        break;
                                    case (4):
                                        freelanceExchange.showListOfOffers();
                                        break;
                                    case (5):
                                        Console.Write("Введите id предложения, которое вы выбрали: ");
                                        try
                                        {
                                            client.buyOffer(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Вы купили услугу!");
                                        break;
                                    case (6):
                                        Console.WriteLine($"Имя админа: {admin.getName()}");
                                        break;
                                    case (7):
                                        request = REQ_GO_BACK;
                                        break;
                                }
                            }
                            break;
                        }
                    case REQ_Worker:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ФРИЛАНСЕР");
                            Console.WriteLine("------------------------------\n");
                            while (request != REQ_GO_BACK)
                            {
                                while (!read_request(ref request, "worker")) { };
                                switch (request)
                                {
                                    case (1):
                                        var t = new List<string>();
                                        Console.Write("От какого имени заявление?: ");
                                        t.Add(Console.ReadLine());
                                        Console.Write("Введите услугу, которую вы предлагаете: ");
                                        t.Add(Console.ReadLine());
                                        Console.Write("Сколько вы хотите получить за это?: ");
                                        t.Add(Console.ReadLine());
                                        worker.tryAddOffer(ref freelanceExchange, t);
                                        Console.WriteLine("Ваше заявление отправлено на рассмотрение!");
                                        break;
                                    case (2):
                                        freelanceExchange.showWaitListOfOffers();
                                        break;
                                    case (3):
                                        Console.Write("Введите id вашего заявления, которое хотите удалить: ");
                                        try
                                        {
                                            worker.delOffer(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Заявление удалено!");
                                        break;
                                    case (4):
                                        freelanceExchange.showListOfRequests();
                                        break;
                                    case (5):
                                        Console.Write("Введите id предложения, которое вы выбрали: ");
                                        try
                                        { 
                                            worker.doRequest(ref freelanceExchange, Int32.Parse(Console.ReadLine()));
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Введены неверные данные!");
                                            continue;
                                        }
                                        Console.WriteLine("Отлично! Можете приступить к исполнению!");
                                        break;
                                    case (6):
                                        Console.WriteLine($"Имя админа: {admin.getName()}");
                                        break;
                                    case (7):
                                        request = REQ_GO_BACK;
                                        break;
                                }
                            }
                            
                            break;
                        }
                    case REQ_LOOKER:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ВЫ ЗАШЛИ ПРОСТО ПОЛЮБОВАТЬСЯ");
                            Console.WriteLine("------------------------------\n");
                            while (request != REQ_GO_BACK)
                            {
                                read_request(ref request, "look");
                                switch (request)
                                {
                                    case (1):
                                        freelanceExchange.showListOfOffers();
                                        break;
                                    case (2):
                                        freelanceExchange.showListOfRequests();
                                        break;
                                    case (3):
                                        Console.WriteLine($"Имя админа: {admin.getName()}");
                                        break;
                                    case (4):
                                        request = REQ_GO_BACK;
                                        break;
                                    default:
                                        Console.WriteLine("Введены неверные данные!");
                                        break;
                                }
                            }
                            break;
                        }
                    case REQ_EXIT:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("СПАСИБО ЗА ПОСЕЩЕНИЕ!");
                            Console.WriteLine("------------------------------\n");
                            continue;
                        }
                    default:
                        Console.WriteLine("Введены неверные данные!");
                        break;
                }
            }
        }
    }
}
