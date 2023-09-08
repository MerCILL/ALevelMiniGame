using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Interfaces
{
    internal interface ICharacter
    {
        int BaseHealth { get; set; }
        int BaseDamage { get; set;  }
        int BaseBlock { get; set;  }
        public int AttackBonus { get; set; }
        List<IEquipment> Equipment { get; set; }
        string UltimateDescription { get; }

        int Attack();
        int Block();
        int UseUltimate();
        ICharacter ResetCharacter();
    }
}
