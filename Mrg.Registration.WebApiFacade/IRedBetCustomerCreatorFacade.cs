
using Mrg.Registration.Contract.DataTransferObjects;
using System;

namespace Mrg.Registration.WebApiFacade
{
    public interface IRedBetCustomerCreatorFacade
    {
        Guid CreateCustomer(string firstName, string lastName, string address, string favoriteTeam);
        Customer ViewCustomer(Guid guid);
        void DeleteCustomer(Guid guid);
        void EditCustomer(Guid guid);
    }
}