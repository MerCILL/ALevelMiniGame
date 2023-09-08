using Module2MiniGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Models.EquipmentModel
{
    internal abstract class Equipment : IEquipment
    {
        public EquipmentType EquipementType { get; set; }
        public abstract string Title { get; }
        public int DamageImpact { get; set; }
        public int BlockImpact { get; set; }

        public Equipment()
        {
        }

        public Equipment(int damageImpact, int blockImpact)
        {
            this.DamageImpact = damageImpact;
            this.BlockImpact = blockImpact;
        }

    }
}
