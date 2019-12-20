using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class AttackTypes : IEnemy
    {
        protected IEnemy _enemy;

        public abstract float attack();

        public abstract string printAttackText();
    }
}
