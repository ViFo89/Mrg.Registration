using System.Collections.Generic;

namespace Mrg.Registration.Domain
{
    public class Customer
    {
        public List<ICustomerInformation> CustomerInformationList { get; internal set; }
    }
}
