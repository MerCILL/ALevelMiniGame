using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2MiniGame.Interfaces
{
    internal interface IEquipment
    {
        EquipmentType EquipementType { get; set; }
        string Title { get; set; }
        int DamageImpact { get; set;  }  
        int BlockImpact { get; set;  }
    }
}
