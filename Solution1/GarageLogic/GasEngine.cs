using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if ((i_GasAmountToFill + m_CurrentEnergy) > MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy, 0, "Amount of gas to fill");
            }
            m_CurrentEnergy = m_CurrentEnergy + i_GasAmountToFill;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
    }
}
