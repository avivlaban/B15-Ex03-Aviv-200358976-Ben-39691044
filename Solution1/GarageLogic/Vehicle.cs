using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_RegistrationNumber;
        private float m_EnergyLeft;
        private float m_PrecentageOfEnergyLeft;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        protected Vehicle(string i_ModelName, string i_RegistrationNumber, float i_PrecentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_RegistrationNumber = i_RegistrationNumber;
            m_PrecentageOfEnergyLeft = i_PrecentageOfEnergyLeft;
            m_Wheels = i_Wheels;
        }

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }

            set
            {
                m_EnergyLeft = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return m_RegistrationNumber;
            }
        }

        public float PrecentageOfEnergyLeft
        {
            get
            {
                return m_PrecentageOfEnergyLeft;
            }

            set
            {
                m_PrecentageOfEnergyLeft = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ModelName: {0}, Licence Plate: {1}, Precentage Of Energy Left: {2}%, {3}\n", m_ModelName, m_RegistrationNumber, m_PrecentageOfEnergyLeft, Wheels[0].ToString());
        }
    }
}
