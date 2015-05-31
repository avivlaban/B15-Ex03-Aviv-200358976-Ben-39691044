using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
   
        public ElectricEngine(float i_CurrentElectric, float i_MaxElectric)
            : base(i_CurrentElectric, i_MaxElectric)
        {
        }
        
        public void ChargeBattery(float i_HoursToCharge)
        {
            if ((m_CurrentEnergy + i_HoursToCharge) > MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy, 0, "Number of hours to charge");
            }
            m_CurrentEnergy = m_CurrentEnergy + i_HoursToCharge;
        }
    }
}
