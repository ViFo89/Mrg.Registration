namespace Mrg.Registration.Domain.Creators
{
    public class RedBetInformationCreator
    {
        public RedBetInformation Create(string favoriteTeam)
        {
            if (string.IsNullOrEmpty(favoriteTeam))
            {
                throw new System.Exception("Invalid favorite team");
            }
            
            return new RedBetInformation
            {
                FavoriteTeam = favoriteTeam
            };
        }
    }
}
