using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_WrongInput;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_WrongInput)
            : base()
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_WrongInput = i_WrongInput;
        }

        public override string Message
        {
            get
            {
                return string.Format("Exeption: {0} Input is out of proper range. Input should be in the range: {1) - {2}", m_WrongInput, m_MinValue, m_MaxValue);
            }
        }
    }
}
