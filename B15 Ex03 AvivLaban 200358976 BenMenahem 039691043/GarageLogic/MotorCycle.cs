using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class MotorCycle : Vehicle
    {        
        internal const int k_NumberOfWheels = 2;
        private const string k_ToStringDetails =
@"{0}Number Of Wheels: {1}
Engine Volume: {2}
Licence Type: {3}
";
        
        private int m_EngineVolume;
        private eLicenceType m_LicenceType;
        
        public MotorCycle(string i_BrandName, string i_RegistrationNumber, float i_PrecentageEnergyLeft, List<Wheel> i_Wheels, eLicenceType i_LicenseType, int i_EngineVolume)
            : base(i_BrandName, i_RegistrationNumber, i_Wheels)
        {
            m_LicenceType = i_LicenseType;
            if (i_EngineVolume <= 0)
            {
                throw new ArgumentException("Illegal Engine Volume.");
            }
            else
            {
                m_EngineVolume = i_EngineVolume;
            }
        }

        public override string ToString()
        {
            return string.Format(k_ToStringDetails, base.ToString(), k_NumberOfWheels, m_EngineVolume, m_LicenceType);
        }
    }
}
