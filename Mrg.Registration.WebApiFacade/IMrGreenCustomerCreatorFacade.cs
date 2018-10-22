using Mrg.Registration.Contract;
using System;

namespace Mrg.Registration.WebApiFacade
{
    public interface IMrGreenCustomerCreatorFacade
    {
        Guid CreateCustomer(string firstName, string lastName, string address, string personalNumber);
        Contract.DataTransferObjects.Customer ViewCustomer(Guid id);
        void EditCustomer(Guid guid);
        void DeleteCustomer(Guid guid);
    }
}