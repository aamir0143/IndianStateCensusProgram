using IndianStateCensusProgram;
using IndianStateCensusProgram.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace IndianStateCensusTestProgram
{
    [TestClass]
    public class IndianStateAnalyserTest
    {
        //AAA Methodlogy
        //Arrange
        //List of file paths
        string stateCensusFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndianPopulations.csv";
        string wrongTypeFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        //List of file paths for indian state code(UC2)
        string stateCodeFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndiaStateCode.csv";
        string wrongSCodeFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndiaStateCodes.csv";
        string wrongSCodeTypeFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\IndiaStateCode.txt";
        string wrongSCodeDelimiterFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongSCodeHeaderFilePath = @"E:\BridgeLabz102\IndianStateCensusProgram\IndianStateCensusPrograms\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //Object for csv adapter class
        CSVAdapterFactory csv; 
        Dictionary<string, CensusDTO> stateCensusRecords;
        Dictionary<string, CensusDTO> stateCodeRecords;
        //Initializing the objects
        [TestInitialize]
        public void Setup()
        {
            csv = new CSVAdapterFactory();
            stateCensusRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }
        //Test case for returning the total count from census and state code if path is correct(UC1-TC1.1 && UC2-TC2.1)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenStateCodeOrCensusCsvReturnRecordsCount()
        {
            stateCensusRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, stateCensusHeaders);
            stateCodeRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeFilePath, stateCodeHeaders);
            Assert.AreEqual(29, stateCensusRecords.Count);
            Assert.AreEqual(37, stateCodeRecords.Count);
        }

        //Test case for returning the file not found custom exception if path is incorrect(UC1-TC1.2 && UC2-TC2.2)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.exception);
        }

        //Test case for returning the invalid file type custom exception if file name is same and extension is different(UC1-TC1.3 && UC2-TC2.3)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongFileTypeThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeTypeFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.exception);
        }

        //Test case for returning the incorrect delimeter in data custom exception if path is correct(UC1-TC1.4 && UC2-TC2.4)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongDelimiterThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeDelimiterFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.exception);
        }

        //Test case for returning the incorrect header custom exception if path is correct(UC1-TC1.5  && UC2-TC2.5)
        [TestCategory("Indian State Census And Code")]
        [TestMethod]
        public void GivenWrongeHeaderThrowsCustomException()
        {
            var customCensusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, stateCensusHeaders));
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongSCodeHeaderFilePath, stateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customCensusException.exception);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.exception);
        }
    }
}
