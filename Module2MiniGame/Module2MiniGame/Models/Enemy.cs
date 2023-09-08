using static System.Console;
using Module2MiniGame.Interfaces;

namespace Module2MiniGame.Models
{
    internal class Enemy : ICharacter
    {
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>();

        public int BaseHealth { get; set; } = 80;
        public int BaseDamage { get; set; } = 15;
        public int BaseBlock { get; set; } = 5;
        public int AttackBonus { get; set; }

        public string UltimateDescription => "Unleashes a devastating attack.";

        public int Attack()
        {
            var totalDamage = BaseDamage;

            // Учесть бонусы от экипировки и других факторов
            foreach (var equipment in Equipment)
            {
                totalDamage += equipment.AttackBonus;
            }

            WriteLine($"Enemy attacks for {totalDamage} damage!");

            return totalDamage;
        }

        public int Block()
        {
            WriteLine($"Enemy tries to defend and blocks for {BaseBlock} damage!");
            return BaseBlock;
        }

        public int UseUltimate()
        {
            WriteLine(UltimateDescription);

            var ultimateDamage = BaseDamage * 2; // Удвоение базового урона для ультимативной атаки врага
            WriteLine($"Enemy uses ultimate attack for { ultimateDamage } damage!");

            return ultimateDamage;
        }

        public ICharacter ResetCharacter()
        {
            return new Enemy(); // Создаем нового врага с базовыми характеристиками
        }

    }
}
