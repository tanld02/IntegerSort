using System.Collections.Generic;
using Xunit;
using SortIntegerNumber;
namespace SortInteger.Test
{
    public class UnitTest1
    {
        [Fact]
        public void SortFirstLastMaxItemResultShouldBe()
        {
            //Arrange
            var list = new List<int>() { 1, -1, 4, 5, 6, 7, 8, 9, 10, -2, -6, 9, 8, 7, 0 };
            var expectationResult = new List<int>() { 4, 5, 6,  7, 7,1 , -1, -2 , -6, 0, 7, 8, 8, 9, 9 };

            //Act
            var result = (SortIntegerNumber.SortInteger.SortFirstLastMaxItem(list, 5, 5).ConfigureAwait(false)).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(expectationResult, result);
        }

        [Fact]
        public void SortFirstLastMaxItemResultShouldBeExeptRangeMaximuIsZero()
        {
            //Arrange
            var list = new List<int>() { 1, -1, 4, 5, 6, 7, 8, 9, 10, -2, -6, 9, 8, 7, 0 };
            var expectationResult = new List<int>() { 1, -1, 4, 5, 6, 7, 8, 9, 10, -2, -6, 9, 8, 7, 0 };

            //Act
            var result = (SortIntegerNumber.SortInteger.SortFirstLastMaxItem(list, 0, 0).ConfigureAwait(false)).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(expectationResult, result);
        }

        [Fact]
        public void GetRangeMaximumNumberShouldBe()
        {
            //Arrange
            var list = new List<int>() { 1, -1, 4, 5, 6, 7, 8, 9, 10, -2, -6, 9, 8, 7, 0 };
            var expResultFirstMaxNumber = new List<int>() { 4, 5, 6, 7, 7 };
            var expResultSecondMaxNumber = new List<int>() { 7, 8, 8, 9, 9 };

            //Act
            var result = (SortIntegerNumber.SortInteger.GetRangeMaximumNumber(list, 5, 5).ConfigureAwait(false)).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(expResultFirstMaxNumber, result.Item1);
            Assert.Equal(expResultSecondMaxNumber, result.Item2);

        }
    }
}