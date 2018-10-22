using Mrg.Registration.Contract;
using Mrg.Registration.Contract.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mrg.Registration.WebApiFacade
{
    public class MrGreenCustomerCreatorFacade: IMrGreenCustomerCreatorFacade
    {
        private readonly ICustomerWebApi _customerWebApi;
        private readonly JsonSerializerSettings Setting;

        public MrGreenCustomerCreatorFacade(ICustomerWebApi customerWebApi)
        {
            _customerWebApi = customerWebApi;
            Setting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public Guid CreateCustomer(string firstName, string lastName, string address, string personalNumber)
        {
            var command = new CreateCustomerCommand
            {
                CustomerInformationList = new List<ICustomerInformation>
                {
                    new GeneralInformation(firstName, lastName, address),
                    new MrGreenInformation(personalNumber)
                }
            };

            var setting = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            var json = JsonConvert.SerializeObject(command, setting);

            // HTTP call
            return _customerWebApi.Post(json);
        }

        public void DeleteCustomer(Guid guid)
        {
            _customerWebApi.Delete(guid);
        }

        public void EditCustomer(Guid guid)
        {
            //_customerWebApi.Put();
        }

        public Customer ViewCustomer(Guid id)
        {
            var json = _customerWebApi.Get(id);
            var obj = JsonConvert.DeserializeObject<Customer>(json, Setting);
            return obj;
        }
    }
}