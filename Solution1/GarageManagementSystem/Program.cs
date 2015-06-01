using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageLogic.GarageLogic garageToManage = new GarageLogic.GarageLogic();
            ConsoleUI garageUI = new ConsoleUI();
            garageUI.StartUI(garageToManage);

        }
    }
}
