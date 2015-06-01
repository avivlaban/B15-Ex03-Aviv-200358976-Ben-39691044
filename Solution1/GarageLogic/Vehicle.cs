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
        private const string k_ToStringDetails =
@"
Model Name: {0}
Registration Number: {1}
{2}
{3}
";

        protected Vehicle(string i_ModelName, string i_RegistrationNumber, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_RegistrationNumber = i_RegistrationNumber;
            m_Wheels = i_Wheels;
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
            //return string.Format(k_ToStringDetails, m_ModelName, m_RegistrationNumber, m_PrecentageOfEnergyLeft, Wheels[0].ToString());
            return string.Format(k_ToStringDetails, m_ModelName, m_RegistrationNumber, m_Engine.ToString(), Wheels[0].ToString());
        }
    }
}
