using Module2MiniGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Models.EquipmentModel
{
    internal class Weapon : Equipment
    {
        private static readonly Random _random = new Random();
        private static readonly WeaponTitle[] _titles = (WeaponTitle[])Enum.GetValues(typeof(WeaponTitle));

        public Weapon()
        {
            Title = _titles[_random.Next(0, _titles.Length)].ToString();
            DamageImpact = _random.Next(2, 20);
            BlockImpact = _random.Next(0, 10);
            EquipementType = EquipmentType.Weapon;
        }

        public Weapon(int damageImpact, int blockImpact)
        {
            this.DamageImpact = damageImpact;
            this.BlockImpact = blockImpact;
            this.EquipementType = EquipmentType.Weapon;
            this.Title = _titles[_random.Next(0, _titles.Length)].ToString();
        }

        public Weapon(EquipmentType equipmentType, string Title) : base(equipmentType, Title)
        {
            DamageImpact = _random.Next(2, 20);
            BlockImpact = _random.Next(0, 10);
        }

        public Weapon(IEquipment equipment) : base(equipment) { }

        public Weapon(EquipmentType equipmentType, string Title, int damageImpact, int blockImpact)
            : base(equipmentType, Title, damageImpact, blockImpact) { }

    }
}
