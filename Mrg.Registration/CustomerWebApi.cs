using Mrg.Registration.Contract;
using Mrg.Registration.Domain.Creators;
using Mrg.Registration.WebApi.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mrg.Registration
{
    public class CustomerWebApi : ICustomerWebApi
    {
        private readonly IRepository _repository;
        private readonly JsonSerializerSettings _jsonSetting;

        public CustomerWebApi(IRepository repository)
        {
            _repository = repository;
            _jsonSetting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public string Get(Guid id)
        {
            var domainCustomer = _repository.Get(id);
            var customerDto = domainCustomer.ToDto();

            var json = JsonConvert.SerializeObject(customerDto, _jsonSetting);
            return json;
        }

        public Guid Post(string jsonCustomer)
        {
            var createCustomer = JsonConvert.DeserializeObject<CreateCustomerCommand>(jsonCustomer, _jsonSetting);

            var customerId = Guid.NewGuid();

            var customer = MapCustomer(createCustomer);

            _repository.Save(customerId, customer);
            return customerId;
        }

        private Domain.Customer MapCustomer(CreateCustomerCommand customer)
        {
            var generalInformationCreator = new GeneralInformationCreator();
            var mrGreenInformationCreator = new MrGreenInformationCreator();
            var redBetInformationCreator = new RedBetInformationCreator();

            var generalInformation = customer.CustomerInformationList.OfType<Contract.DataTransferObjects.GeneralInformation>().SingleOrDefault();
            var mrGreenInformation = customer.CustomerInformationList.OfType<Contract.DataTransferObjects.MrGreenInformation>().SingleOrDefault();
            var redBetInformation = customer.CustomerInformationList.OfType<Contract.DataTransferObjects.RedBetInformation>().SingleOrDefault();

            var customerInformationList = new List<Domain.ICustomerInformation>();


            if (generalInformation != null)
            {
                var validGeneralInfo = generalInformationCreator.Create(generalInformation.FirstName, generalInformation.LastName, generalInformation.Address);
                customerInformationList.Add(validGeneralInfo);
            }

            if (mrGreenInformation != null)
            {
                var validMrGreenInfo = mrGreenInformationCreator.Create(mrGreenInformation.PersonalNumber);
                customerInformationList.Add(validMrGreenInfo);
            }
            
            if (redBetInformation != null)
            {
                var validRedBetInfo = redBetInformationCreator.Create(redBetInformation.FavoriteTeam);
                customerInformationList.Add(validRedBetInfo);
            }
            
            var customerCreator = new CustomerCreator();
            return customerCreator.Create(customerInformationList);
        }
    }
}
