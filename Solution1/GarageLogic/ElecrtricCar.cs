using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElecrtricCar : Car
    {
        private const float k_MaxBatteryTime = 2.2F;

        public ElecrtricCar(string i_BrandName, string i_RegistrationNumber, float i_AmountOfEnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, ((i_AmountOfEnergyLeft * 100) / k_MaxBatteryTime), i_Wheels)
        {
            this.EnergyLeft = i_AmountOfEnergyLeft;
            Engine = new ElectricEngine(i_AmountOfEnergyLeft, k_MaxBatteryTime);
        }

        public void ChargeBattery(float i_AmountOfHoursToCharge){
            ElectricEngine batteryTester = Engine as ElectricEngine;

            if (batteryTester == null)
            {
                throw new ArgumentException("Cannot Charge a gas Engine!");
            }

            batteryTester.ChargeBattery(i_AmountOfHoursToCharge);
            this.EnergyLeft = this.EnergyLeft + i_AmountOfHoursToCharge;
            PrecentageOfEnergyLeft = (this.EnergyLeft* 100) / k_MaxBatteryTime;
        }

        public override string ToString()
        {
            return string.Format("{0}, Maximal Battery Time: {1}", base.ToString(), k_MaxBatteryTime);
        }
    }
}
