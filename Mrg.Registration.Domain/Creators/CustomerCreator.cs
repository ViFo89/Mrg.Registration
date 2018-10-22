using System.Collections.Generic;
using System.Linq;

namespace Mrg.Registration.Domain.Creators
{
    public class CustomerCreator : ICustomerCreator
    {
        public Customer Create(List<ICustomerInformation> customerInformationList)
        {
            if(customerInformationList.Any(x => x == null))
            {
                throw new System.Exception("Customer information list can't contain Null");
            }
            return new Customer { CustomerInformationList = customerInformationList };
        }
    }

    public interface ICustomerCreator
    {
        Customer Create(List<ICustomerInformation> customerInformationList);
    }
}
