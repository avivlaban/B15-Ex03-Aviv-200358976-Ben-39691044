using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public abstract class Engine
    {
        protected float m_MaxEnergy;
        protected float m_CurrentEnergy;

        protected Engine(float i_CurrentEnergy, float i_MaxEnergy)
        {
            if (i_MaxEnergy <= 0)
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

        public float PrecentageOfEnergyLeft
        {
            get
            {
                return (CurrentEnergy * 100) / MaxEnergy;
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

        public override abstract string ToString();

    }
}
