namespace Mrg.Registration.Domain.Creators
{
    public class MrGreenInformationCreator
    {
        public MrGreenInformation Create(string personalNumber)
        {
            if (string.IsNullOrEmpty(personalNumber))
            {
                throw new System.Exception("Invalid personal number");
            }
            
            return new MrGreenInformation
            {
                PersonalNumber = personalNumber
            };
        }
    }
}
