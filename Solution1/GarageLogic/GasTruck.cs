using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasTruck : Truck
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxEnergy = 170;

        public GasTruck(string i_BrandName, string i_RegistrationNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, ((i_EnergyLeft * 100) / k_MaxEnergy), i_Wheels)
        {
            
            this.Engine = new GasEngine(i_EnergyLeft, k_MaxEnergy, k_FuelType);
            this.EnergyLeft = i_EnergyLeft;
        }

        public void FillGas(float i_AmountToFill, eFuelType i_FuelType)
        {
            GasEngine gasTester = Engine as GasEngine;

            if (gasTester == null)
            {
                throw new ArgumentException("Cannot fuel Electric engine with Gas!");
            }
            gasTester.fillGas(i_AmountToFill, i_FuelType);
            this.EnergyLeft = this.EnergyLeft + i_AmountToFill;
            this.PrecentageOfEnergyLeft = (this.EnergyLeft * 100) / k_MaxEnergy;
        }

        public override string ToString()
        {
            return string.Format("{0}, Fuel Type: {1}, Maximal Fuel: {2}", base.ToString(), k_FuelType, k_MaxEnergy);
        }
    }
}
