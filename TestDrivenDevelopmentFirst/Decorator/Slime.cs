using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Slime : IEnemy
    {
        public float attack()
        {
            return 10;
        }

        public string printAttackText()
        {
            return "Slime attacks with 10 Damage";
        }
    }
}
