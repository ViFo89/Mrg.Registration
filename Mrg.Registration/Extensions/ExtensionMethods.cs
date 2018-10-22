using System.Collections.Generic;
using System.Linq;

namespace Mrg.Registration.WebApi.Extensions
{
    internal static class ExtensionMethods
    {
        internal static Contract.DataTransferObjects.Customer ToDto(this Domain.Customer customer)
        {
            var informationList = new List<Contract.DataTransferObjects.ICustomerInformation>();

            var generalInfo = customer.CustomerInformationList.OfType<Domain.GeneralInformation>().SingleOrDefault();
            var mrGreenInfo = customer.CustomerInformationList.OfType<Domain.MrGreenInformation>().SingleOrDefault();
            var redBetInfo = customer.CustomerInformationList.OfType<Domain.RedBetInformation>().SingleOrDefault();

            if(generalInfo != null)
            {
                informationList.Add(generalInfo.ToDto());
            }
            if (mrGreenInfo != null)
            {
                informationList.Add(mrGreenInfo.ToDto());
            }
            if (redBetInfo != null)
            {
                informationList.Add(redBetInfo.ToDto());
            }

            return new Contract.DataTransferObjects.Customer
            {
                CustomerInformationList = informationList
            };
        }

        internal static Contract.DataTransferObjects.GeneralInformation ToDto(this Domain.GeneralInformation customer)
        {
            return new Contract.DataTransferObjects.GeneralInformation(customer.FirstName, customer.LastName, customer.Address);
        }

        internal static Contract.DataTransferObjects.MrGreenInformation ToDto(this Domain.MrGreenInformation customer)
        {
            return new Contract.DataTransferObjects.MrGreenInformation(customer.PersonalNumber);
        }

        internal static Contract.DataTransferObjects.RedBetInformation ToDto(this Domain.RedBetInformation customer)
        {
            return new Contract.DataTransferObjects.RedBetInformation(customer.FavoriteTeam);
        }
    }
}
