using Module2MiniGame.Interfaces;

namespace Module2MiniGame.Service;

internal class Game: IGame
{
    public ICharacter Character { get; set; }
    public bool IsUltimateAvailable { get; set; }
    
    private int _initialHealth;
    private int _initialDamage;
    private int _initialBlock;
    private int _currentBlock;
    private int _initialEquipmentDamage;
    private int _initialEquipmentBlock;

    public Game(ICharacter character)
    {
        this.Character = character;
        _initialHealth = character.BaseHealth;
        _initialDamage = character.BaseDamage;
        _initialBlock = character.BaseBlock;
        _currentBlock = character.BaseBlock;
        _initialEquipmentDamage = 0;
        _initialEquipmentBlock = 0;
    }
    
    public void StartBattle()
    {
        throw new NotImplementedException();
    }

    public void ChangeEquipment(EquipmentType equipmentType, string equipmentTitle)
    {
        throw new NotImplementedException();
    }

    public void ShowEquipment(ICharacter character)
    {
        foreach (var eq in character.Equipment)
        {
            Console.WriteLine($"title: {eq.Title}, type: {eq.EquipementType}, " + 
                              $"damage: {eq.DamageImpact}, block: {eq.BlockImpact}\n");
        }
        
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void Attack(int attackPoints)
    {
        int damage = attackPoints - _currentBlock;
        if (damage > 0)
        {
            Character.BaseHealth -= damage;
        }
        _currentBlock = Character.BaseBlock;
    }

    public void Block()
    {
        throw new NotImplementedException();
    }
    
    public void Block(int blockPoints)
    {
        _currentBlock += blockPoints;
    }

    public void UseUltimate(bool IsUltimateAvailable)
    {
        throw new NotImplementedException();
    }

    public void UseUltimate()
    {
        if (IsUltimateAvailable)
        {
            Character.UseUltimate();
            IsUltimateAvailable = false;
        }
    }

    public void ResetCharacterAfterBattle()
    {
        Character.BaseHealth = _initialHealth;
        Character.BaseDamage = _initialDamage;
        Character.BaseBlock = _initialBlock;
        IsUltimateAvailable = true;
    }

    public void SetEquipment(int index)
    {
        
        IEquipment equipment = Character.Equipment[index];
        Character.BaseDamage += equipment.DamageImpact - _initialEquipmentDamage;
        Character.BaseBlock += equipment.BlockImpact - _initialEquipmentBlock;
    }
}