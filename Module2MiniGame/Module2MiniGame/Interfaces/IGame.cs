using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Interfaces
{
    internal interface IGame
    {
        ICharacter character { get; set;  }
         
        bool IsUltimateAvailable { get; set; }
        void StartBattle();
        void ChangeEquipment(EquipmentType equipmentType, string equipmentTitle);
        void ShowEquipment(ICharacter character);
        void Attack();
        void Block();
        void UseUltimate(bool IsUltimateAvailable);
        void ResetCharacterAfterBattle();
    }
}
