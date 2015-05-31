using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Coustumer
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eClientStatus m_ClientStatus;
        private Vehicle m_Vehicle;

        public Coustumer(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_ClientStatus = eClientStatus.InRepair;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
        }

        public eClientStatus ClientStatus
        {
            get
            {
                return m_ClientStatus;
            }

            set
            {
                m_ClientStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        private string getCoustumerVehicleStatus()
        {
            string coustumerVehicleStatus = string.Empty;

            if(this.m_ClientStatus.Equals(eClientStatus.InRepair))
            {
                coustumerVehicleStatus = "In Repair";
            }
            else if(this.m_ClientStatus.Equals(eClientStatus.Paid))
            {
                coustumerVehicleStatus = "Paid";
            }
            else
            {
                coustumerVehicleStatus = "Repaired";
            }

            return coustumerVehicleStatus;
        }

        public override string ToString()
        {
            return string.Format("Owner Name: {0}, Owner Phone: {1}, Vehicle: {2}", m_OwnerName, m_OwnerPhone, m_Vehicle.ToString());
        }
    }
}
