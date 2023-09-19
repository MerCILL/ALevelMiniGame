namespace Module2MiniGame.Interfaces
{
    internal interface ICharacter
    {
        List<IEquipment> Equipment { get; set; }
        List<string> Names { get; set; }


        int BaseHealth { get; set; }
        int BaseDamage { get; set; }
        int BaseBlock { get; set; }

        string UltimateDescription { get; }

        int Attack();
        int Block();
        int UseUltimate();
        ICharacter ResetCharacter();
    }
}