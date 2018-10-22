using System;

namespace Mrg.Registration
{
    public interface ICustomerWebApi
    {
        Guid Post(string jsonCustomer);

        string Get(Guid id);

        void Delete(Guid id);


    }
}