﻿using Module2MiniGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Models.EquipmentModel
{
    internal class Armor : Equipment
    {
        private static readonly Random _random = new Random();
        private static readonly ArmorTitle[] _titles = (ArmorTitle[])Enum.GetValues(typeof(ArmorTitle));
        public override string Title => _titles[_random.Next(0, _titles.Length)].ToString();

        public Armor()
        {
            DamageImpact = _random.Next(0, 10);
            BlockImpact = _random.Next(2, 20);
            EquipementType = EquipmentType.Armor;
        }

        public Armor(int damageImpact, int blockImpact)
        {
            this.DamageImpact = damageImpact;
            this.BlockImpact = blockImpact;
            this.EquipementType = EquipmentType.Armor;
        }

    }
}
