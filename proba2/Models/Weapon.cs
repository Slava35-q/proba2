using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba2.Models
{
    public class Weapon
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public double BaseDamage { get; set; }
    }
}
