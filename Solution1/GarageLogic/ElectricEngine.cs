using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        private const string k_ToStringDetails =
@"Battery Based Engine:
Current Energy Percentage: {0}%
Current Charge Time: {1}
Max Charge Time: {2}";
        
        public ElectricEngine(float i_CurrentElectric, float i_MaxElectric)
            : base(i_CurrentElectric, i_MaxElectric)
        {
        }
        
        public void ChargeBattery(float i_HoursToCharge)
        {
            if ((CurrentEnergy + i_HoursToCharge) > MaxEnergy)
            {
                throw new ValueOutOfRangeException((MaxEnergy - CurrentEnergy) * 60, 0, "Number of hours to charge");
            }

            CurrentEnergy = CurrentEnergy + i_HoursToCharge;
        }

        public override string ToString()
        {
            return string.Format(k_ToStringDetails, PrecentageOfEnergyLeft, m_CurrentEnergy, m_MaxEnergy);
        }
    }
}
