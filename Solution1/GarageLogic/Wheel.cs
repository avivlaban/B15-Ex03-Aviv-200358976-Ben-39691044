using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private const float k_MinimalAirPressure = 0;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private const float m_MaxAirPressure;

        public void fillAirInWheel(float i_airToAdd){
            if((i_airToAdd + m_CurrentAirPressure) > m_MaxAirPressure){
                throw new ValueOutOfRangeException(m_MaxAirPressure, k_MinimalAirPressure, "Amount of air added to the wheel");
            }

            m_CurrentAirPressure = (i_airToAdd + m_CurrentAirPressure);
        }
    }
}
