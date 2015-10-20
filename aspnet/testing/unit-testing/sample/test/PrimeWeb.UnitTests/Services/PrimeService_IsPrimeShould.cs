using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PrimeWeb.Services;

namespace PrimeWeb.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;
        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, String.Format("{0} should not be prime", value));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void ReturnTrueGivenPrimesLessThan10(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.True(result, String.Format("{0} should be prime", value));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void ReturnFalseGivenNonPrimesLessThan10(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, String.Format("{0} should not be prime", value));
        }

    }
}
