using System;
using System.Collections.Generic;
using System.Text;
namespace IndianStateCensusProgram.DataDAO 
{
    /// <summary>
    /// Created The Class For Indian State Census Data Access Object(UC1)
    /// </summary>
    public class StateCodeDataDAO
    {
        //Declaring variables
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        //Declaring parameterized contructor for initializing values
        public StateCodeDataDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
