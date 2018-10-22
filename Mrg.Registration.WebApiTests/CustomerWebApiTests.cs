using Moq;
using Mrg.Registration.Contract;
using Mrg.Registration.Contract.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mrg.Registration.WebApiTests
{
    public class CustomerWebApiTests
    {
        private readonly JsonSerializerSettings _setting;
        private readonly ICustomerWebApi sut;

        private readonly Mock<IRepository> _testRepo;

        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string Address = "Address";

        private Domain.Customer actualCustomer;

        public CustomerWebApiTests()
        {
            _setting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            _testRepo = new Mock<IRepository>();
            _testRepo.Setup(x => x.Save(It.IsAny<Guid>(), It.IsAny<Domain.Customer>()))
                                  .Callback<Guid, Domain.Customer>((guid, c) => actualCustomer = c);

            sut = new CustomerWebApi(_testRepo.Object);
        }


        [Fact]
        public void When_creating_a_new_customer()
        {
            var command = new CreateCustomerCommand
            {
                CustomerInformationList = new List<ICustomerInformation>
                {
                    new GeneralInformation(FirstName, LastName, Address)
                }
            };

            var json = JsonConvert.SerializeObject(command, _setting);

            sut.Post(json);

            var actualGeneralInfo = actualCustomer.CustomerInformationList.OfType<Domain.GeneralInformation>().Single();

            Assert.NotNull(actualCustomer);
            Assert.Equal(FirstName, actualGeneralInfo.FirstName);
            Assert.Equal(LastName, actualGeneralInfo.LastName);
            Assert.Equal(Address, actualGeneralInfo.Address);
        }
    }
}
