using Mrg.Registration.Domain;
using Mrg.Registration.Domain.Creators;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mrg.Registration.DomainTests
{
    public class CustomerCreatorTests
    {
        private readonly CustomerCreator sut;

        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string Address = "Address";

        private readonly GeneralInformation _generalInformation;

        public CustomerCreatorTests()
        {
            sut = new CustomerCreator();
            var generalInformationCreator = new GeneralInformationCreator();

            _generalInformation = generalInformationCreator.Create(FirstName, LastName, Address);

        }

        [Fact]
        public void When_valid_information_is_added()
        {
            var list = new List<ICustomerInformation> { _generalInformation };

            var customer = sut.Create(list);

            Assert.NotNull(customer);
            Assert.NotNull(customer.CustomerInformationList);
            Assert.IsType<GeneralInformation>(customer.CustomerInformationList.Single());
        }

        [Fact]
        public void When_invalid_information_is_added()
        {
            var list = new List<ICustomerInformation> { null };

            Assert.Throws<System.Exception>(() => sut.Create(list));
        }
    }
}
