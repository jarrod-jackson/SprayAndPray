using SprayAndPray.Models;
using Xunit;
using Moq;

namespace SprayAndPray.Business.Tests
{
    /// <summary>
    ///     Tests for <see cref="CustomerHandler"/>
    /// </summary>
    public class CustomerHandlerTests : IClassFixture<CustomerHandler>
    {
        /// <summary>
        ///     Customer Handler Class
        /// </summary>
        private readonly CustomerHandler _mockCustomerHandler;

        /// <summary>
        ///     Desiganted Constructor
        /// </summary>
        /// <param name="mockCustomerHandler"></param>
        public CustomerHandlerTests(
            CustomerHandler mockCustomerHandler)
        {
            _mockCustomerHandler = mockCustomerHandler;
        }

        /// <summary>
        ///     Theory Data for <see cref="ValidateCustomerUpdate_ShouldReturnTrue_WhenCustomerAndIdArePopulated(int?, Customer?, bool)"/>
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> ValidateCustomerUpdateTheoryData()
        {
            yield return new object[] { 1, GetCustomer(), true };
            yield return new object[] { 0, GetCustomer(), false };
            yield return new object[] { null, GetCustomer(), false };
            yield return new object[] { 1, null, false };
            yield return new object[] { 0, null, false };
            yield return new object[] { null, null, false };
        }
        
        [Theory]
        [MemberData(nameof(ValidateCustomerUpdateTheoryData))]
        public void ValidateCustomerUpdate_ShouldReturnTrue_WhenCustomerAndIdArePopulated(
            int? id,
            Customer? customerDto,
            bool expectedOutcome)
        {
            // Arrange
            var idBeingPassedIntoMethod = id;
            var customer = customerDto;

            var expectedResult = expectedOutcome;

            // Act
            var actualResult = _mockCustomerHandler.ValidateCustomerUpdate(customer, idBeingPassedIntoMethod);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        private static Customer GetCustomer()
        {
            return new Customer
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                PhoneNumber = "",
                Email = "",
                Address = "",
                CreatedDateTime = DateTime.Now
            };
        }
    }
}