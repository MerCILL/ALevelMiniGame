using Module2MiniGame.Interfaces;
using Module2MiniGame.Models.EquipmentModel;

namespace Module2MiniGame
{
    internal class Program
    {
        static void Main()
        {
            GameInterface game = new GameInterface();
            game.RunApp();
        }
    }
}

