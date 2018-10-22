namespace Mrg.Registration.Contract.DataTransferObjects
{
    public class GeneralInformation : ICustomerInformation
    {
        public GeneralInformation(string firstName, string lastName, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}