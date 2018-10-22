using Mrg.Registration.Contract.DataTransferObjects;
using System.Collections.Generic;

namespace Mrg.Registration.Contract
{
    public class CreateCustomerCommand
    {
        public List<ICustomerInformation> CustomerInformationList { get; set; }
    }
}
