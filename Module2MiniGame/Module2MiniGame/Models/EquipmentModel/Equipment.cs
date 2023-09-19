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
        public string Title { get; set;  }
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

        public Equipment(EquipmentType equipmentType, string Title)
        {
            this.EquipementType = equipmentType;
            this.Title = Title;
        }

        public Equipment(IEquipment equipment)
        {
            this.EquipementType = equipment.EquipementType;
            this.Title = equipment.Title;
            this.DamageImpact = equipment.DamageImpact;
            this.BlockImpact = equipment.BlockImpact;
        }

        public Equipment(EquipmentType equipmentType, string Title, int damageImpact, int blockImpact)
        {
            this.EquipementType = equipmentType;
            this.Title = Title;
            this.DamageImpact = damageImpact;
            this.BlockImpact = blockImpact;
        }

    }
}
