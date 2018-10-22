namespace Mrg.Registration.Domain
{
    public class GeneralInformation : ICustomerInformation
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Address { get; internal set; }
    }
}