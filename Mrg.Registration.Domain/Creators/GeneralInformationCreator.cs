namespace Mrg.Registration.Domain.Creators
{
    public class GeneralInformationCreator
    {
        public GeneralInformation Create(string firstName, string lastName, string address)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new System.Exception("Invalid first name");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new System.Exception("Invalid last name");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new System.Exception("Invalid address");
            }


            return new GeneralInformation
            {
                FirstName = firstName,
                Address = address,
                LastName = lastName
            };
        }
    }
}
