using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class GasEngine : Engine
    {
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
                throw new ArgumentException("The Gas type is not the right one.");
            }

            if ((i_GasAmountToFill + CurrentEnergy) > MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy, 0, "Amount of gas to fill");
            }

            CurrentEnergy = CurrentEnergy + i_GasAmountToFill;
            PrecentegeOfEnergyLeft = (CurrentEnergy * 100) / MaxEnergy;
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
            return string.Format("{0}, Fuel Type: {1}", base.ToString(), m_FuelType);
        }
    }
}
