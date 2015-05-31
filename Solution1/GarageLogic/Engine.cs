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
        internal float m_CurrentEnergy;

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
        }

        public float energyPercent
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

    }
}
