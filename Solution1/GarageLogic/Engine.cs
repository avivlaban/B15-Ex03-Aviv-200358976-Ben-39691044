using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Engine
    {
        private float m_MaxEnergy;
        private float m_CurrentEnergy;
        private float m_PrecentegeOfEnergyLeft;

        protected Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            if (m_MaxEnergy <= 0)
            {
                throw new ArgumentException("Error: Max Energy should be positive");
            }

            if (i_CurrentEnergy > i_MaxEnergy || i_CurrentEnergy < 0)
            {
                throw new ValueOutOfRangeException(i_MaxEnergy, 0, "Error: Invalid inputs for amount of energy");
            }

            m_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
            m_PrecentegeOfEnergyLeft = (i_CurrentEnergy * 100) / m_MaxEnergy;  
        }

        public float PrecentegeOfEnergyLeft
        {
            get
            {
                return m_PrecentegeOfEnergyLeft;
            }

            set
            {
                m_PrecentegeOfEnergyLeft = value;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

        public override string ToString()
        {
            return string.Format("Current Energy: {0}, Max Energy Capacity: {1}\n", m_CurrentEnergy, m_MaxEnergy);
        }
    }
}
