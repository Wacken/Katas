using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class EarthAttacker : AttackTypes
    {
        public EarthAttacker(IEnemy enemy)
        {
            _enemy = enemy;
        }

        public override float attack()
        {
            return 23 + _enemy.attack();
        }

        public override string printAttackText()
        {
            return $"{_enemy.printAttackText()} and 23 Earth Damage";
        }
    }
}
