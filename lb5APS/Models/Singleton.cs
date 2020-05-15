using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lb5APS.Models
{
    public class Singleton
    {
        //конструктор який створює нову бд
        private Singleton()
        {
            this.db = new EventDBEntities();
        }
        private EventDBEntities db;
        private static Singleton _instance;

        //перевірка на існування змінної
        public static Singleton Build()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }

        //повертає елемент з обраним часом
        public List<Event> ShowElByHour(int clock)
        {
            return this.db.Event.Where(c => c.Date_Time.Hour == clock).ToList();
        }

        //додає едемент до бд
        public List<Event> AddEl(Event e)
        {
            var newEvent = this.db.Event.Add(e);
            this.db.SaveChanges();
            return this.db.Event.ToList();
        }

        //очищує всі події
        public void DelEl()
        {
            foreach(Event e in this.db.Event)
            {
                this.db.Event.Remove(e);
            }
            this.db.SaveChanges();
        }
    }
}