using System;
using System.Collections.Generic;
using System.Text;

namespace hm_2
{
    public class People
    {
        protected string name;
        public People(string name_)
        {
            name = name_;
        }
        

        public string getName() { return name; }
        
        Admin getАdmin(FreelanceExchange FE) { return FE.admin; }
    }
    public class Admin : Moderator
    {
        public Admin(string name_) : base(name_) { }

        public void addModerator(ref FreelanceExchange FE, Moderator mod)
        {
            if (!FE.moderatorList.Contains(mod))
                FE.moderatorList.Add(mod);
        }

        public void delModerator(ref FreelanceExchange FE, int id)
        {
            FE.moderatorList.Remove(FE.moderatorList[id]);
        }
    }

    public class Moderator : People
    {
        
        public Moderator(string name_) : base(name_) { }
        List<Moderator> getModeratorList(FreelanceExchange FE) { return FE.moderatorList; }

        public void addOffer(ref FreelanceExchange FE, int id)
        {
            FE.listOfOffers.Add(FE.waitOfferList[id]);
            FE.waitOfferList.Remove(FE.waitOfferList[id]);
        }

        public void deleteOffer(ref FreelanceExchange FE, int id)
        {
            FE.listOfOffers.Remove(FE.listOfOffers[id]);
        }

        public void addRequest(ref FreelanceExchange FE, int id)
        {
            FE.listOfRequests.Add(FE.waitReqList[id]);
            FE.waitReqList.Remove(FE.waitReqList[id]);
        }

        public void deleteRequest(ref FreelanceExchange FE, int id)
        {
            FE.listOfRequests.Remove(FE.listOfRequests[id]);
        }
    }

    public class Client : People
    {
        public Client(string name_) : base(name_) { }

        public void tryAddRequest(ref FreelanceExchange FE, List<string> req)
        {
            FE.waitReqList.Add(req);
        }

        public void delRequest(ref FreelanceExchange FE, int id)
        {
           FE.waitReqList.Remove(FE.waitReqList[id]);
        }
        
        public void buyOffer(ref FreelanceExchange FE, int id) {
            FE.listOfOffers.Remove(FE.listOfOffers[id]);
        }
    }

    public class Worker : People
    {
        public Worker(string name_) : base(name_) { }


        public void tryAddOffer(ref FreelanceExchange FE, List<string> off)
        {
            FE.waitOfferList.Add(off);
        }

        public void delOffer(ref FreelanceExchange FE, int id)
        {
            FE.waitOfferList.Remove(FE.waitOfferList[id]);
        }
        // req имя / что нужно / цена / сколько раз уже заказывал
        // off имя / что могу / цена / стаж
        public void doRequest(ref FreelanceExchange FE, int id)
        {
            FE.listOfRequests.Remove(FE.listOfRequests[id]);
        }
    }
    public class FreelanceExchange
    {
        public Admin admin;
        public List<Moderator> moderatorList = new List<Moderator>();

        public List<List<string>> listOfOffers = new List<List<string>>();
        public List<List<string>> listOfRequests = new List<List<string>>();

        public List<List<string>> waitOfferList = new List<List<string>>();
        public List<List<string>> waitReqList = new List<List<string>>();
        

        public FreelanceExchange(Admin admin_)
        {
            admin = admin_;
            Console.WriteLine("\nФриланс биржа создана!\n");
        }

        public void showListOfOffers()
        {
            Console.WriteLine($"Список предложений\nid | Имя исполнителя | предлагаемая услуга | цена");
            for (int i = 0; i < listOfOffers.Count; i++)
            {
                var t = listOfOffers[i];
                Console.WriteLine($"{i}. {t[0]} | {t[1]} | {t[2]}");
            }
            Console.WriteLine();
        }

        public void showListOfRequests()
        {
            Console.WriteLine($"Список предложений\nid | Имя заказчика | требуемая услуга | цена");
            for (int i = 0; i < listOfRequests.Count; i++)
            {
                var t = listOfRequests[i];
                Console.WriteLine($"{i}. {t[0]} | {t[1]} | {t[2]}");
            }
            Console.WriteLine();
        }
        public void showModeratorList()
        {
            Console.WriteLine($"Список модераторов\nИмя");
            for (int i = 0; i < moderatorList.Count; i++)
            {
                var t = moderatorList[i];
                Console.WriteLine($"{i}. {t.getName()}");
            }
            Console.WriteLine();
        }

        // req имя / что нужно / цена / сколько раз уже заказывал
        public void showWaitListOfRequests()
        {
            Console.WriteLine($"Список, ожидающий рассмотрения\nid - Имя заказчика - требуемая услуга - цена");
            for (int i = 0; i < waitReqList.Count; i++)
            {
                var t = waitReqList[i];
                Console.WriteLine($"{i}. {t[0]} | {t[1]} | {t[2]}");
            }
            Console.WriteLine();
        }
        // off имя / что могу / цена / стаж
        public void showWaitListOfOffers()
        {
            Console.WriteLine($"Список, ожидающий рассмотрения\nid - Имя заказчика - предлагаемая услуга - цена");
            for (int i = 0; i < waitOfferList.Count; i++)
            {
                var t = waitOfferList[i];
                Console.WriteLine($"{i}. {t[0]} | {t[1]} | {t[2]}");
            }
            Console.WriteLine();
        }
    }
}   
