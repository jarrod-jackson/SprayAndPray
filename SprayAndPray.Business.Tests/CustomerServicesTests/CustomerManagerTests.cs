using SprayAndPray.Models;
using Xunit;
using Moq;

namespace SprayAndPray.Business.Tests.CustomerServicesTests
{
    /// <summary>
    ///     Tests for <see cref="CustomerManager"/>
    /// </summary>
    public class CustomerManagerTests : IClassFixture<CustomerManager>
    {
        /// <summary>
        ///     Customer Manager Class
        /// </summary>
        private readonly CustomerManager _mockCustomerManager;

        /// <summary>
        ///     Desiganted Constructor
        /// </summary>
        /// <param name="mockCustomerManager"></param>
        public CustomerManagerTests(
            CustomerManager mockCustomerHandler)
        {
            _mockCustomerManager = mockCustomerHandler;
        }

        /// <summary>
        ///     Theory Data for <see cref="ValidateCustomerUpdate_ShouldReturnTrue_WhenCustomerAndIdArePopulated(int?, Customer?, bool)"/>
        /// </summary>
        /// <returns>Theory Data</returns>
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
            var actualResult = _mockCustomerManager.ValidateCustomerUpdate(customer, idBeingPassedIntoMethod);

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