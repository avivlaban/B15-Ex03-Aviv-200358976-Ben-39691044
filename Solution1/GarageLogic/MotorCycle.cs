using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class MotorCycle : Vehicle
    {
        internal const int k_NumberOfWheels = 2;
        private int m_EngineVolume;
        private eLicenceType m_LicenceType;
        private float m_MaxPressure;

        public MotorCycle(string i_BrandName, string i_RegistrationNumber, float i_PrecentageEnergyLeft, List<Wheel> i_Wheels)
            : base(i_BrandName, i_RegistrationNumber, i_PrecentageEnergyLeft, i_Wheels)
        {
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public eLicenceType LicenceType
        {
            get
            {
                return m_LicenceType;
            }

            set
            {
                m_LicenceType = value;
            }
        }

        public float MaxPressure
        {
            get
            {
                return m_MaxPressure;
            }

            set
            {
                m_MaxPressure = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Number Of Wheels: {1}, Engine Volume: {2}, Licence Type: {3}\n", base.ToString(), k_NumberOfWheels, m_EngineVolume, m_LicenceType);
        }
    }
}
