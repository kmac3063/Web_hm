using System;
using System.Collections.Generic;
using System.Text;

namespace hm_2
{
    public class people
    {
        float balance;
        public string name;
    }
    public class admin : moderator
    {

    }

    public class moderator : people
    {

    }

    public class client : people
    {

    }

    public class worker : people
    {

    }
    public class freelanceExchange
    {
        admin admin_;
        moderator[] moderatorList_;
        
        worker[] ListOfWorkers_;
        string[][] ListOfOffers_;

        client[] ListOfClients_;
        string[][] ListOfRequests_;

        public freelanceExchange(string AdminName)
        {
            admin_.name = AdminName;
            Console.WriteLine("\nФриланс биржа создана!\n");
        }

        string adminName(){ return admin_.name; }
        void showAdminName(){ Console.WriteLine($"\nИмя админа: {admin_.name}\n"); }


        people[] moderatorList(){ return moderatorList_; }
        void showModeratorList()
        {
            Console.WriteLine($"\n Список модераторов: имя - стаж");
            for (int i = 0; i < moderatorList_.Length; i++)
            {
                moderator t = moderatorList_[i];
                Console.WriteLine($"{i}. {t.name}, {t.experience}");
            }
            Console.WriteLine();
        }


        void showListOfOffers()
        {
            Console.WriteLine($"\nСписок предложений: имя исполнителя - предлагаемая услуга - цена - стаж");
            for (int i = 0; i < ListOfOffers_.Length; i++)
            {
                string[] t = ListOfOffers_[i];
                Console.WriteLine($"{i}. {t[0]}, {t[1]}, {t[2]}, {t[3]}");
            }
            Console.WriteLine();
        }
        worker[] ListOfWorkers() { return ListOfWorkers_; }
        void showListOfWorkers()
        {
            Console.WriteLine($"\nСписок исполнителей: имя - стаж - количество выполненых работ");
            for (int i = 0; i < ListOfWorkers_.Length; i++)
            {
                worker t = ListOfWorkers_[i];
                Console.WriteLine($"{i}. {t.name} - {t.experience} - {t.score}");
            }
            Console.WriteLine();
        }

        void showListOfRequests()
        {
            Console.WriteLine($"\nСписок предложений: имя заказчика - требуемая услуга - цена");
            for (int i = 0; i < ListOfRequests_.Length; i++)
            {
                string[] t = ListOfRequests_[i];
                Console.WriteLine($"{i}. {t[0]}, {t[1]}, {t[2]}");
            }
            Console.WriteLine();
        }
        client[] ListOfClient() { return ListOfClients_; }
        void showListOfClient()
        {
            Console.WriteLine($"\nСписок заказчиков: имя - опубликовано заявок");
            for (int i = 0; i < ListOfClients_.Length; i++)
            {
                client t = ListOfClients_[i];
                Console.WriteLine($"{i}. {t.name} - {t.numberOfRequests}");
            }
            Console.WriteLine();
        }
    }
}   
