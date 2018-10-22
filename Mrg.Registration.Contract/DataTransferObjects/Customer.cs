using System.Collections.Generic;

namespace Mrg.Registration.Contract.DataTransferObjects
{
    public class Customer
    {
        public List<ICustomerInformation> CustomerInformationList { get; set; }

    }
}
