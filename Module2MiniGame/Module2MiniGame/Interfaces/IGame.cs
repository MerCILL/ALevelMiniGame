using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Interfaces
{
    internal interface IGame
    {
        ICharacter Character { get; set; }
        bool IsUltimateAvailable { get; set; }
        void StartBattle();
        void ChangeEquipment(EquipmentType equipmentType, string equipmentTitle);
        void ShowEquipment(ICharacter character);
        void Attack();
        void Attack(int attackPoints);
        void Block();
        void Block(int blockPoints);
        void UseUltimate(bool IsUltimateAvailable);
        void UseUltimate();
        void ResetCharacterAfterBattle();
        void SetEquipment(int index);
    }
}
