using System;
using System.Collections.Generic;
using System.Text;

namespace ScannerSite.entity
{
    class Game
    {

        //-2 не данных
        //-1 бесплатно
        //остальное цена из стима
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }

        public Game(string name)
        {
            this.Name = name;
            this.Cost = -2;
        }

        public Game(string name, double cost, DateTime date)
        {
            this.Name = name;
            this.Cost = cost;
            this.Date = date;
        }

    }
}
