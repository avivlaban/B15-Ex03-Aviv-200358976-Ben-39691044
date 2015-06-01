using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class GasEngine : Engine
    {
        private const string k_ToStringDetails =
@"Gasoline Based Engine:
Current Energy Percentage: {0:0.##}%
Current Amount of gas (in liters): {1}
Max Amount of gas (in liters): {2}
Fuel Type: {3}";

        private eFuelType m_FuelType;

        public GasEngine(float i_CurrentGas, float i_MaxGas, eFuelType i_FuelType)
            : base(i_CurrentGas, i_MaxGas)
        {
            this.m_FuelType = i_FuelType;
        }

        public void fillGas(float i_GasAmountToFill, eFuelType i_FuelType)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException(string.Format("{0} is not the right type. Please use {1}", i_FuelType, m_FuelType));
            }

            if ((i_GasAmountToFill + CurrentEnergy) > MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy - CurrentEnergy, 0, "Amount of gas to fill");
            }

            CurrentEnergy = CurrentEnergy + i_GasAmountToFill;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public override string ToString()
        {
            return string.Format(k_ToStringDetails, PrecentageOfEnergyLeft, m_CurrentEnergy, m_MaxEnergy, m_FuelType);
        }
    }
}
