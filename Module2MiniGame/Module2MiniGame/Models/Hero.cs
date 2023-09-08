using static System.Console;
using Module2MiniGame.Interfaces;

namespace Module2MiniGame.Models
{
    internal class Hero : ICharacter
    {
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>();

        public bool Heal { get; set; }
        public int BaseHealth { get; set; } = 100;
        public int BaseDamage { get; set; } = 20;
        public int BaseBlock { get; set; } = 10;
        public int AttackBonus { get; set; }

        public string UltimateDescription => "Unleashes a powerful attack.";

        public int Attack()
        {
            var totalDamage = BaseDamage;

            // Учесть бонусы от экипировки и других факторов
            foreach (var equipment in Equipment)
            {
                totalDamage += equipment.AttackBonus;
            }

            WriteLine($"Hero attacks for {totalDamage} damage!");

            return totalDamage;
        }

        public int Block()
        {
            WriteLine($"Hero raises their shield and blocks for {BaseBlock} damage!");
            return BaseBlock;
        }

        public int UseUltimate()
        {
            WriteLine(UltimateDescription);

            var ultimateDamage = BaseDamage * 2;   // Удвоение базового урона для ультимативной атаки
            WriteLine($"Hero uses ultimate attack for {ultimateDamage} damage!");

            return ultimateDamage;
        }

        public ICharacter ResetCharacter()
        {
            return new Hero(); // Создаем нового героя с базовыми характеристиками
        }
    }
}
