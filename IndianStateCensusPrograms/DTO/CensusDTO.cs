using IndianStateCensusProgram.DataDAO;
using System;
using System.Collections.Generic;
using System.Text;
namespace IndianStateCensusProgram.DTO 
{
    /// <summary>
    /// Created The State Data Transfer Object For Different DAO(UC1) 
    /// </summary>
    public class CensusDTO
    {
        //Declaring variables
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public double totalArea;
        public double waterArea;
        public double landArea;
        //Declaring parameterized contructor for initializing values
        public CensusDTO(StateCodeDataDAO stateCodeDataDAO)
        {
            this.serialNumber = stateCodeDataDAO.serialNumber;
            this.stateName = stateCodeDataDAO.stateName;
            this.tin = stateCodeDataDAO.tin;
            this.stateCode = stateCodeDataDAO.stateCode;
        }
        //Declaring parameterized contructor for initializing values
        public CensusDTO(PopulationDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }

    }
}
