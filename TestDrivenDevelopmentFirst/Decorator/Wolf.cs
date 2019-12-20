using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Wolf : IEnemy
    {
        public float attack()
        {
            return 30;
        }

        public string printAttackText()
        {
            return "Wolf attacks with 30 Damage";
        }
    }
}
