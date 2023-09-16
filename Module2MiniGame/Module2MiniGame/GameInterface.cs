using System.Reflection.Metadata;
using Module2MiniGame.Models;
using Module2MiniGame.Models.EquipmentModel;
using Module2MiniGame.Service;

namespace Module2MiniGame;
using Module2MiniGame.Interfaces;


public class GameInterface
{
    private Random _random = new Random();
    private const int MinHealthPoints = 50;
    private const int MaxHealtPoints = 300;
    private const int MinDamagePoints = 20;
    private const int MaxDamagePoints = 50;
    private const int MinBlock = 10;
    private const int MaxBlock = 40;
    private const int ArmorAmountToChoose = 3;
    private const int WeaponAmountToChoose = 3;
    private ICharacter? _hero;
    private ICharacter? _enemy;
    private IGame? _heroService;
    private IGame? _enemyService;
    
    
    
    public void RunApp()
    {
        while (true)
        {
            Console.WriteLine("Pres any key to start game, or 'exit' to quit");
            var input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                return;
            }

            StartGame();
        }
    }

    void StartGame()
    {
        _hero = GetCharacter("hero");
        _heroService = new Game(_hero);
        SetEquipmentHero();
        _enemy = GetCharacter("enemy");
        _enemyService = new Game(_enemy);
        SetEquipmentEnemy();
        PlayGame();
    }
    private void PlayGame()
    {
        while (true)
        {
            DisplayCharacter(_heroService.Character, "Hero");
            DisplayCharacter(_enemyService.Character, "Enemy");
            if (_enemyService.Character.BaseHealth <= 0)
            {
                Console.WriteLine("You win! Searching for a new enemy...");
                ResetEnemy();
            }
            if (_heroService.Character.BaseHealth <= 0)
            {
                Console.WriteLine("Game over, you dead!");
                return;
            }
            ChoseHeroAction();
            ChoseEnemyAction();
        }
    }

    private void ChoseEnemyAction()
    {
        int randomAction = _random.Next(1, 4);
        switch (randomAction)
        {
            case 1: EnemyAttack(); 
                return;
            case 2: EnemyBlock(); 
                return;
            case 3: EnemyUseUltimate(); 
                return;
            case 4: SetEquipmentEnemy();;
                return;
            default: Console.WriteLine("Wrong action!");
                break;
        }
        
    }
    private void ChoseHeroAction()
    {
        while (true)
        {
            Console.WriteLine("Chose action: 1 - attack, 2 - block, 3 - use ultimate, 4 - change equipment");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": HeroAttack(); 
                    return;
                case "2": HeroBlock(); 
                    return;
                case "3": HeroUseUltimate(); 
                    return;
                case "4": SetEquipmentHero(); 
                    return;
                default: Console.WriteLine("Wrong action!");
                    break;
            }
        }
    }

   
    
    private void EnemyUseUltimate()
    {
        int oldDamageValue = _enemyService.Character.UseUltimate();
        int damagePoints = _enemyService.Character.Attack();
        _heroService.Attack(damagePoints);
        _enemyService.Character.BaseDamage = oldDamageValue;
    }

    private void HeroUseUltimate()
    {
        int oldDamageValue = _heroService.Character.UseUltimate();
        int damagePoints = _heroService.Character.Attack();
        _enemyService.Attack(damagePoints);
        _heroService.Character.BaseDamage = oldDamageValue;
    }
    private void HeroBlock()
    {
        int blockPoints = _heroService.Character.Block();
        _heroService.Block(blockPoints);
    }

    private void EnemyBlock()
    {
        int blockPoints = _enemyService.Character.Block();
        _enemyService.Block(blockPoints);
    }
    private void HeroAttack()
    {
        int damagePoints = _heroService.Character.Attack();
        _enemyService.Attack(damagePoints);
    }

    private void EnemyAttack()
    {
        int damage = _enemyService.Character.Attack();
        _heroService.Attack(damage);
    }
    private void ResetEnemy()
    {
        _enemy = GetCharacter("enemy");
        _enemyService = new Game(_enemy);
        _heroService.ResetCharacterAfterBattle();
        DisplayCharacter(_heroService.Character, "Hero");
        DisplayCharacter(_enemyService.Character, "Enemy");
    }

    private void DisplayCharacter(ICharacter character, string type)
    {
        Console.WriteLine($"{type}: health: {character.BaseHealth}, " +
                          $"block: {character.BaseBlock}, " +
                          $"damage: {character.BaseDamage}, \n" +
                          $"Ultimate description: {character.UltimateDescription}\n" +
                          $"Equipment: {EquipmentToString(character.Equipment)}");

    }

    private string EquipmentToString(List<IEquipment> equipment)
    {
        string res = "";
        int count = 0;
        foreach (var eq in equipment)
        {
            res += $"{++count} - title: {eq.Title}, type: {eq.EquipementType}, damage: {eq.DamageImpact}, block: {eq.BlockImpact}\n";
        }
    
        return res;
    }

    private ICharacter GetCharacter(string character)
    {
        int health = _random.Next(MinHealthPoints, MaxHealtPoints);
        int damage = _random.Next(MinDamagePoints, MaxDamagePoints);
        int block = _random.Next(MinBlock, MaxBlock);
        ICharacter res = character.Equals("hero") ? new Hero() : new Enemy();
        res.BaseHealth = health;
        res.BaseDamage = damage;
        res.BaseBlock = block;
        res.Equipment = character.Equals("hero") ? GetEquipment() 
            : GenerateEquipment();
        return res;
    }

    private void SetEquipmentHero()
    {
        int index = 0;
        bool flOpen = true;
        while (flOpen)
        {
            Console.WriteLine("Chose equipment, enter 1 or 2:");
            Console.WriteLine(EquipmentToString(_heroService.Character.Equipment));
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": index = 0;
                    flOpen = false;
                    break;
                case "2": index = 1;
                    flOpen = false;
                    break;
                default: Console.WriteLine("Wrong input!");
                    break;
            }
        }

        _heroService.SetEquipment(index);
    }

    private void SetEquipmentEnemy()
    {
        int index = _random.Next(0, 2);
        _heroService.SetEquipment(index);
    }
    private List<IEquipment> GetEquipment()
    {
        List<IEquipment> equipment = new List<IEquipment>();
        IEquipment armor = GetArmor();
        IEquipment weapon = GetWeapon();
        equipment.Add(armor);
        equipment.Add(weapon);
        return equipment;
    }

    private List<IEquipment> GenerateEquipment()
    {
        List<IEquipment> equipment = new List<IEquipment>();
        List<IEquipment> armorList = GenerateArmor();
        List<IEquipment> equipmentList = GenerateWeapon();
        IEquipment armor = armorList.ElementAt(_random.Next(0, armorList.Count));
        IEquipment weapon = equipmentList.ElementAt(_random.Next(0, equipmentList.Count));
        equipment.Add(armor);
        equipment.Add(weapon);
        return equipment;
    }

    private IEquipment GetArmor()
    {
        List<IEquipment> armorList = GenerateArmor();
        IEquipment armor;
        while (true)
        {
            Console.WriteLine("Chose armor for your hero from given list: 1, 2, 3....");
            DisplayEquipment(armorList, "Armor");
            string input = Console.ReadLine();
            int index = -1;
            bool isInt = int.TryParse(input, out index);
            index--;
            if (isInt && index >= 0 && index < armorList.Count)
            {
                armor = armorList.ElementAt(index);
                break;
            }
            Console.WriteLine("Wrong input try again");
        }
        
        return armor;
    }

    private IEquipment GetWeapon()
    {
        List<IEquipment> weaponList = GenerateWeapon();
        IEquipment  weapon;
        while (true)
        {
            Console.WriteLine("Chose  weapon for your hero from given list: 1, 2, 3....");
            DisplayEquipment(weaponList, "Weapon");
            string input = Console.ReadLine();
            int index = -1;
            bool isInt = int.TryParse(input, out index);
            index--;
            if (isInt && index >= 0 && index <  weaponList.Count)
            {
                weapon = weaponList.ElementAt(index);
                break;
            }
            Console.WriteLine("Wrong input try again");
        }
        
        return  weapon;
    }

    private List<IEquipment> GenerateArmor()
    {
        List<IEquipment> armorList = new List<IEquipment>();
        for (int i = 0; i < ArmorAmountToChoose; i++)
        {
            armorList.Add(new Armor());
        }

        return armorList;
    }
    
    private List<IEquipment> GenerateWeapon()
    {
        List<IEquipment> weaponList = new List<IEquipment>();
        for (int i = 0; i < WeaponAmountToChoose; i++)
        {
            weaponList.Add(new Weapon());
        }

        return weaponList;
    }

    private void DisplayEquipment(List<IEquipment> equipmentList, string type)
    {
        for(int i = 0; i < equipmentList.Count; i++)
        {
            Console.WriteLine($"{type}-{i + 1}: title: {equipmentList[i].Title}; " +
                              $"equipemant type: {equipmentList[i].EquipementType}; " +
                              $"block impact: {equipmentList[i].BlockImpact}; " +
                              $"damage impact: {equipmentList[i].DamageImpact};");
        }
    }
    

    


}