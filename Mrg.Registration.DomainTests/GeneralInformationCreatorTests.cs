using Mrg.Registration.Domain.Creators;
using System;
using Xunit;

namespace Mrg.Registration.DomainTests
{
    public class GeneralInformationCreatorTests
    {
        private readonly GeneralInformationCreator sut;

        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string Address = "Address";

        private const string InvalidFirstName = "";
        private const string InvalidLastName = "";
        private const string InvalidAddress = "";

        public GeneralInformationCreatorTests()
        {
            sut = new GeneralInformationCreator();
        }

        [Fact]
        public void When_valid_GeneralInformation_is_created()
        {
            var generalInformation = sut.Create(FirstName, LastName, Address);

            Assert.Equal(FirstName, generalInformation.FirstName);
            Assert.Equal(LastName, generalInformation.LastName);
            Assert.Equal(Address, generalInformation.Address);
        }

        [Fact]
        public void When_invalid_firstName()
        {
            Assert.Throws<Exception>(() => sut.Create(InvalidFirstName, LastName, Address));
        }

        [Fact]
        public void When_invalid_lastName()
        {
            Assert.Throws<Exception>(() => sut.Create(InvalidLastName, LastName, Address));
        }

        [Fact]
        public void When_invalid_address()
        {
            Assert.Throws<Exception>(() => sut.Create(InvalidAddress, LastName, Address));
        }
    }
}
