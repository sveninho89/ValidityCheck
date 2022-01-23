using System;
using ValidityCheck;
using Xunit;

namespace ValidityCheck.Tests
{
    public class MetoderTests
    {



        private readonly Metoder _sut;

        public MetoderTests()
        {
            _sut = new Metoder();
        }


        [Theory]
        [InlineData("198906255958", "8906255958")]
        [InlineData("201701102384", "1701102384")]
        [InlineData("189912299816", "9912299816")]
        [InlineData("19890625-5958", "890625-5958")]
        public void Change12to10Test_ShouldRemove2chars(string personnummer, string expected)
        {
            
            string actual = _sut.Change12to10(personnummer);
            

            Assert.Equal(actual, expected);
        }


        [Theory]
        [InlineData("8906255958", "8906255958")]
        [InlineData("890625-5958", "890625-5958")]
        [InlineData("900118+9811", "900118+9811")]
        [InlineData("4607137454", "4607137454")]
        public void Change12to10Test_ShouldNotRemove2chars(string personnummer, string expected)
        {

            string actual = _sut.Change12to10(personnummer);


            Assert.Equal(actual, expected);
        }


        [Theory]
        [InlineData("8906255958", "8906255958")]
        [InlineData("890625-5958", "8906255958")]
        [InlineData("900118+9811", "9001189811")]
        [InlineData("abcdefghijklmnopqrstuvxyz:4607137454", "4607137454")]
        public void RemoveAllCharsTest_ShouldRemoveAllCharsExceptNumbers(string personnummer, string expected)
        {

            string actual = _sut.RemoveAllChars(personnummer);


            Assert.Equal(actual, expected);
        }


        
        
        [Theory]
        [InlineData("8906255958", "8")] //Personnummer
        [InlineData("890625595", "8")] //Personnummer
        [InlineData("0910799824", "4")] //Samordning
        [InlineData("091079982", "4")] //Samordning
        [InlineData("5566016399", "9")] //Orgnr
        [InlineData("556601639", "9")] //Orgnr
        public void LuhnsAlgoritm_ShouldFindCorrectNumber(string personnummer, string expected)
        {

            string actual = _sut.LuhnsAlgoritm(personnummer);


            Assert.Equal(actual, expected);
            
        }


        [Theory]
        [InlineData("8906255958", "8")]
        [InlineData("9001189811", "1")]
        [InlineData("4607137454", "4")]
        [InlineData("1701272394", "4")]
        [InlineData("0302299813", "3")]
        [InlineData("1234567895", "5")]
        public void KontrolleraSiffraTest_ShouldIdentify10thNumber(string personnummer, string expected)
        {

            string actual = _sut.KontrolleraSiffra(personnummer);


            Assert.Equal(actual, expected);
        }



        [Theory]
        [InlineData("8906255958", "falskt")] //personnummer
        [InlineData("9001189811", "falskt")] //personnummer
        [InlineData("1701272394", "falskt")] //ogiltigt personummer
        [InlineData("0910799824", "sant")] //samordningnr
        [InlineData("5566016399", "falskt")] //orgnr
        [InlineData("8572027566", "falskt")] //orgnr

        public void KontrolleraSamordningTest_ShouldVerifyIfTrueOrFalse(string personnummer, string expected)
        {

            string actual = _sut.KontrolleraSamordning(personnummer);


            Assert.Equal(actual, expected);
        }



        [Theory]
        [InlineData("8906255958", "falskt")] //personnummer
        [InlineData("9001189811", "falskt")] //personnummer
        [InlineData("1701272394", "falskt")] //ogiltigt personummer
        [InlineData("0910799824", "falskt")] //samordningnr
        [InlineData("5566016399", "sant")] //orgnr
        [InlineData("8572027566", "sant")] //orgnr

        public void KontrolleraOrgnrTest_ShouldVerifyIfTrueOrFalse(string personnummer, string expected)
        {

            string actual = _sut.KontrolleraOrgnr(personnummer);


            Assert.Equal(actual, expected);
        }



    }
}