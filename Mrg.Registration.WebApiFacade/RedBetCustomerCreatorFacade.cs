using Mrg.Registration.Contract;
using Mrg.Registration.Contract.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mrg.Registration.WebApiFacade
{
    public class RedBetCustomerCreatorFacade: IRedBetCustomerCreatorFacade
    {

        private readonly ICustomerWebApi _customerWebApi;
        private readonly JsonSerializerSettings Setting;

        public RedBetCustomerCreatorFacade(ICustomerWebApi customerWebApi)
        {
            _customerWebApi = customerWebApi;
            Setting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public Guid CreateCustomer(string firstName, string lastName, string address, string favoriteTeam)
        {
            var command = new CreateCustomerCommand
            {
                CustomerInformationList = new List<ICustomerInformation>
                {
                    new GeneralInformation(firstName, lastName, address),
                    new RedBetInformation(favoriteTeam)
                }
            };


            var json = JsonConvert.SerializeObject(command, Setting);

            // HTTP call
            return _customerWebApi.Post(json);
        }

        public void DeleteCustomer(Guid guid)
        {
            _customerWebApi.Delete(guid);
        }

        public void EditCustomer(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Customer ViewCustomer(Guid guid)
        {
            var json = _customerWebApi.Get(guid);
            // Customer should not be the domain object but it will do for now
            var obj = JsonConvert.DeserializeObject<Customer>(json, Setting);
            return obj;
        }
    }
}