using static System.Console;
using Module2MiniGame.Interfaces;

namespace Module2MiniGame.Models
{
    internal class Enemy : ICharacter
    {
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>(2);
        public List<string> Names { get; set; } = new List<string> { "Troll", "Goblin" };


        public int BaseHealth { get; set; } = 80;
        public int BaseDamage { get; set; } = 15;
        public int BaseBlock { get; set; } = 5;

        public string UltimateDescription => "Unleashes a devastating attack.";

        public Enemy()
        {
            // Инициализация случайных характеристик врага
            var random = new Random();
            BaseHealth = random.Next(60, 100); // Задайте диапазон для здоровья врага
            BaseDamage = random.Next(10, 25); // Задайте диапазон для урона врага
            BaseBlock = random.Next(2, 10); // Задайте диапазон для блока врага

            // Инициализация случайного снаряжения
            GenerateRandomEquipment();
        }

        private void GenerateRandomEquipment()
        {
            var random = new Random();
            var equipmentTypes = Enum.GetValues(typeof(EquipmentType)).Cast<EquipmentType>().ToList();

            foreach (var equipmentType in equipmentTypes)
            {
                // Генерация случайного снаряжения для каждого типа
                var equipment = new Equipment  // Нужен класс
                {
                    EquipementType = equipmentType,
                    Title = GetRandomEquipmentTitle(equipmentType),
                    DamageImpact = random.Next(5, 15), // Задайте диапазон для воздействия урона
                    BlockImpact = random.Next(1, 5), // Задайте диапазон для воздействия блока
                    AttackBonus = random.Next(1, 5) // Задайте диапазон для бонуса атаки
                };

                Equipment.Add(equipment);
            }
        }

        private string GetRandomEquipmentTitle(EquipmentType equipmentType)
        {
            // Генерация случайного названия снаряжения на основе типа снаряжения
            var random = new Random();
            switch (equipmentType)
            {
                case EquipmentType.Weapon:
                    var weaponNames = new[] { "Sword", "Axe", "Mace", "Dagger" };
                    return weaponNames[random.Next(weaponNames.Length)];
                case EquipmentType.Armor:
                    var armorNames = new[] { "Helmet", "Chestplate", "Shield", "Boots" };
                    return armorNames[random.Next(armorNames.Length)];
                default:
                    return "Unknown";
            }
        }

        public int Attack()
        {
            var totalEquipmentDamage = Equipment.Sum(e => e.DamageImpact);
            return BaseDamage + totalEquipmentDamage;
        }

        public int Block()
        {
            var totalEquipmentBlock = Equipment.Sum(e => e.BlockImpact);
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
            return new Enemy()
            {
                Equipment = new List<IEquipment>(Equipment)
            }; // Создаем нового врага с базовыми характеристиками
        }
    }
}