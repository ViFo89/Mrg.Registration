namespace Mrg.Registration.Contract.DataTransferObjects
{

    public class MrGreenInformation : ICustomerInformation
    {
        public MrGreenInformation(string personalNumber)
        {
            PersonalNumber = personalNumber;
        }

        public string PersonalNumber { get; set; }
    }
}