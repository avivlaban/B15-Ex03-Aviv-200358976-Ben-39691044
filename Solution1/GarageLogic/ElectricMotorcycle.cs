using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricMotorcycle : MotorCycle
    {
        private const float k_MaxPressure = 31;
        private const float k_MaxEnergy = 1.2F;

        public ElectricMotorcycle(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, ((i_EnergyLeft * 100) / k_MaxEnergy), i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > k_MaxPressure)
            {
                throw new ValueOutOfRangeException(k_MaxPressure, 0, "Pressure in Wheel");
            }
            this.Engine = new ElectricEngine(i_EnergyLeft, k_MaxEnergy);
            this.EnergyLeft = i_EnergyLeft;
        }

        public void FillBattery(float i_ElectricityToAddInHours)
        {
            ElectricEngine electricTester = Engine as ElectricEngine;

            if (electricTester == null)
            {
                throw new ArgumentException("Cannot fill Gas in Electric Motorcycle!");
            }
            electricTester.ChargeBattery(i_ElectricityToAddInHours);
            this.EnergyLeft = this.EnergyLeft + i_ElectricityToAddInHours;
            this.PrecentageOfEnergyLeft = (this.EnergyLeft * 100) / k_MaxEnergy;
        }

        public override string ToString()
        {
            return string.Format("{0}, Maximal Pressure in Wheels: {1}, Maximal Battery Time: {2)", base.ToString(), k_MaxPressure, k_MaxEnergy);
        }
    }
}
