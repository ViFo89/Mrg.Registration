namespace Mrg.Registration.Contract.DataTransferObjects
{

    public class RedBetInformation : ICustomerInformation
    {
        public RedBetInformation(string favoriteTeam)
        {
            FavoriteTeam = favoriteTeam;
        }

        public string FavoriteTeam { get; set; }
    }
}