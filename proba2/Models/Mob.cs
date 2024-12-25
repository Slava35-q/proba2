using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba2.Models
{
    public class Mob
    {
        public required string Name { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
        public double DamageDealt { get; set; } // Итоговый урон
    }
}
