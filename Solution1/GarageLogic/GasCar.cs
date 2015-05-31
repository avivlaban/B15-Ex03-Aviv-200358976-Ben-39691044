using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasCar : Car
    {
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const float k_MaxEnergy = 35;
        
        public GasCar(string i_BrandName, string i_RegistrationNumber, float i_AmountOfEnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, ((i_AmountOfEnergyLeft * 100) / k_MaxEnergy), i_Wheels)
        {
            this.EnergyLeft = i_AmountOfEnergyLeft;
            this.Engine = new GasEngine(i_AmountOfEnergyLeft, k_MaxEnergy, k_FuelType);
        }

        public void FillGas(float i_GasToAdd, eFuelType i_FuelType)
        {
            GasEngine gasTester = this.Engine as GasEngine;
            if (gasTester == null)
            {
                throw new ArgumentException("Cannot fuel an Electric Car with Gas!");
            }
            gasTester.fillGas(i_GasToAdd, i_FuelType);
            this.EnergyLeft = this.EnergyLeft + i_GasToAdd;
            PrecentageOfEnergyLeft = (this.EnergyLeft * 100) / k_MaxEnergy; 
        }

        public override string ToString()
        {
            return string.Format("{0}, Maximal Energy: {1}, Fuel Type: {2}", base.ToString(), k_MaxEnergy, k_FuelType);
        }
    }
}
