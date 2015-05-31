using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasMotorCycle : MotorCycle
    {
        private const float k_MaxPressure = 34;
        private const float k_MaxEnergy = 8;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        public GasMotorCycle(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, ((i_EnergyLeft * 100) / k_MaxEnergy), i_Wheels)
        {
            if (i_Wheels[0].CurrentPressureInWheel > k_MaxPressure)
            {
                throw new ValueOutOfRangeException(k_MaxPressure, 0, "Pressure in Wheel");
            }
            this.Engine = new GasEngine(i_EnergyLeft, k_MaxEnergy, k_FuelType);
            this.EnergyLeft = i_EnergyLeft;
        }

        public void FillGas(float i_GasToAdd, eFuelType i_FuelType)
        {
            GasEngine gasTester = Engine as GasEngine;
            if (gasTester == null)
            {
                throw new ArgumentException("Cannot fill an electric Motorcycle with Gas!");
            }
            gasTester.fillGas(i_GasToAdd, i_FuelType);
            this.EnergyLeft = this.EnergyLeft + i_GasToAdd;
            this.PrecentageOfEnergyLeft = (this.EnergyLeft * 100) / k_MaxEnergy;
        }

        public override string ToString()
        {
            return string.Format("{0}, Maximal Amount of fuel: {1}, Fuel Type: {2}, Maximal Pressure in Wheels: {3}", base.ToString(), k_MaxEnergy, k_FuelType, k_MaxPressure);
        }
    }
}
