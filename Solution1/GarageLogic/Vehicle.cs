using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_RegistrationNumber;
        List<Wheel> m_Wheels;
        Engine m_Engine;

    }
}
