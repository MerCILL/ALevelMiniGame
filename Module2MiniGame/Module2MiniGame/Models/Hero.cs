using static System.Console;
using Module2MiniGame.Interfaces;

namespace Module2MiniGame.Models
{
    internal class Hero : ICharacter
    {
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>(2);
        public List<string> Names { get; set; } = new List<string> { "Wizzard", "Warrior" };

        public int BaseHealth { get; set; } = 100;
        public int BaseDamage { get; set; } = 20;
        public int BaseBlock { get; set; } = 10;

        public string UltimateDescription => "Unleashes a powerful attack.";

        public int Attack()
        {
            int totalEquipmentDamage = Equipment.Sum(e => e.DamageImpact);
            return BaseDamage + totalEquipmentDamage;
        }

        public int Block()
        {
            int totalEquipmentBlock = Equipment.Sum(e => e.BlockImpact);
            return BaseBlock + totalEquipmentBlock;
        }

        public int UseUltimate()
        {
            var oldBaseDamage = this.BaseDamage;
            this.BaseDamage *= 2;

            return oldBaseDamage;
        }

        public ICharacter ResetCharacter()
        {
            return new Hero()
            {
                Equipment = new List<IEquipment>(Equipment)
            }; // Создаем нового героя с базовыми характеристиками
        }
    }
}
