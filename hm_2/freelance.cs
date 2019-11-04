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
        //public List<Worker> getListOfWorkers(FreelanceExchange FE) { return FE.listOfWorkers; }
        //public List<Client> getListOfClient(FreelanceExchange FE) { return FE.listOfClients; }

    }
    public class Admin : Moderator
    {
        public Admin(string name_) : base(name_) { }

        public void addModerator(ref FreelanceExchange FE, Moderator mod)
        {
            if (!FE.moderatorList.Contains(mod))
                FE.moderatorList.Add(mod);
        }

        public void delModerator(ref FreelanceExchange FE, Moderator mod)
        {
            if (FE.moderatorList.Contains(mod))
                FE.moderatorList.Remove(mod);
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

        public void delRequest(ref FreelanceExchange FE, List<string> req)
        {
            if (FE.waitReqList.Contains(req))
                FE.waitReqList.Remove(req);
            if (FE.listOfRequests.Contains(req))
                FE.listOfRequests.Remove(req);
        }
        // req имя / что нужно / цена / сколько раз уже заказывал
        // off имя / что могу / цена / стаж
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

        public void delOffer(ref FreelanceExchange FE, List<string> off)
        {
            if (FE.waitOfferList.Contains(off))
                FE.waitOfferList.Remove(off);
            if (FE.listOfOffers.Contains(off))
                FE.listOfOffers.Remove(off);
        }
        // req имя / что нужно / цена / сколько раз уже заказывал
        // off имя / что могу / цена / стаж
        public void doRequest(ref FreelanceExchange FE, int id)
        {
            FE.listOfRequests.Remove(FE.listOfRequests[id]);
        }
        //tryAddOffer
        //pleaseDelOffer
        //workReq
    }
    public class FreelanceExchange
    {
        public Admin admin;
        public List<Moderator> moderatorList = new List<Moderator>();

        //public List<Worker> listOfWorkers = new List<Worker>();
        public List<List<string>> listOfOffers = new List<List<string>>();
        public List<List<string>> listOfRequests = new List<List<string>>();

        public List<List<string>> waitOfferList = new List<List<string>>();
        public List<List<string>> waitReqList = new List<List<string>>();
        //public List<Client> listOfClients = new List<Client>();


        public FreelanceExchange(Admin admin_)
        {
            admin = admin_;
            Console.WriteLine("\nФриланс биржа создана!\n");
        }

        public void showListOfOffers()
        {
            Console.WriteLine($"\nСписок предложений: имя исполнителя - предлагаемая услуга - цена");
            for (int i = 0; i < listOfOffers.Count; i++)
            {
                var t = listOfOffers[i];
                Console.WriteLine($"{i}. {t[0]} - {t[1]} - {t[2]}");
            }
            Console.WriteLine();
        }
        /*void showListOfWorkers()
        {
            Console.WriteLine($"\nСписок исполнителей: имя - стаж - количество выполненых работ");
            for (int i = 0; i < listOfWorkers_.Length; i++)
            {
                Worker t = listOfWorkers_[i];
                Console.WriteLine($"{i}. {t.name} - {t.experience} - {t.score}");
            }
            Console.WriteLine();
        }*/

        public void showListOfRequests()
        {
            Console.WriteLine($"\nСписок предложений: имя заказчика - требуемая услуга - цена");
            for (int i = 0; i < listOfRequests.Count; i++)
            {
                var t = listOfRequests[i];
                Console.WriteLine($"{i}. {t[0]} - {t[1]} - {t[2]}");
            }
            Console.WriteLine();
        }
        /*void showListOfClient()
        {
            Console.WriteLine($"\nСписок заказчиков: имя - опубликовано заявок");
            for (int i = 0; i < listOfClients_.Length; i++)
            {
                Client t = listOfClients_[i];
                Console.WriteLine($"{i}. {t.name} - {t.numberOfRequests}");
            }
            Console.WriteLine();
        }*/
        public void showModeratorList()
        {
            Console.WriteLine($"\n Список модераторов: имя");
            for (int i = 0; i < moderatorList.Count; i++)
            {
                var t = moderatorList[i];
                Console.WriteLine($"{i}. {t.getName()}");
            }
            Console.WriteLine();
        }
    }
}   
