using Mrg.Registration.WebApiFacade;
using Newtonsoft.Json;
using System;

namespace Mrg.Registration.Client
{
    class RegistrationProgram
    {
        private readonly IMrGreenCustomerCreatorFacade _mrGreenCustomerCreatoreFacade;
        private readonly IRedBetCustomerCreatorFacade _redBetCustomerCreatorFacade;

        public RegistrationProgram(IMrGreenCustomerCreatorFacade mrGreenCustomerCreatoreFacade, IRedBetCustomerCreatorFacade redBetCustomerCreatorFacade)
        {
            _mrGreenCustomerCreatoreFacade = mrGreenCustomerCreatoreFacade;
            _redBetCustomerCreatorFacade = redBetCustomerCreatorFacade;
        }

        public void Run()
        {
            string action = string.Empty;
            do
            {
                action = PropmtForAction();

                switch (action)
                {
                    case "1":
                        CreateRedBetCustomer();
                        break;
                    case "2":
                        CreateMrGreenCustomer();
                        break;
                    case "3":
                        ViewRedBetCustomer();
                        break;
                    case "4":
                        ViewMrGreenCustomer();
                        break;
                    case "5":
                        EditRedBetCustomer();
                        break;
                    case "6":
                        EditMrGreenCustomer();
                        break;
                    case "7":
                        DeleteRedBetCustomer();
                        break;
                    case "8":
                        DeleteMrGreenCustomer();
                        break;
                }
            } while (action != "0");

        }

        private void DeleteMrGreenCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            _mrGreenCustomerCreatoreFacade.DeleteCustomer(Guid.Parse(id));
        }

        private void DeleteRedBetCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            _redBetCustomerCreatorFacade.DeleteCustomer(Guid.Parse(id));
        }

        private void EditMrGreenCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            _mrGreenCustomerCreatoreFacade.EditCustomer(Guid.Parse(id));
        }

        private void EditRedBetCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            _redBetCustomerCreatorFacade.EditCustomer(Guid.Parse(id));
        }

        private string PropmtForAction()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Create RedBet Customer");
            Console.WriteLine("2. Create MrGreen Customer");
            Console.WriteLine("3. View RedBet customer");
            Console.WriteLine("4. View MrGreen customer");
            Console.WriteLine("5. *NOT DONE* Edit RedBet customer");
            Console.WriteLine("6. *NOT DONE* Edit MrGreen customer");
            Console.WriteLine("7. Delete RedBet customer");
            Console.WriteLine("8. Delete MrGreen customer");
            Console.WriteLine("0. Quit");

            return Console.ReadLine();
        }

        private void CreateRedBetCustomer()
        {
            Console.WriteLine("FirstName:");
            var firstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Address:");
            var address = Console.ReadLine();
            Console.WriteLine("FavoriteFootballTeam:");
            var favoriteFootballTeam = Console.ReadLine();

            var id = _redBetCustomerCreatorFacade.CreateCustomer(firstName, lastName, address, favoriteFootballTeam);
            Console.WriteLine(id);
        }

        private void CreateMrGreenCustomer()
        {
            Console.WriteLine("FirstName:");
            var firstName = Console.ReadLine();
            Console.WriteLine("LastName:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Address:");
            var address = Console.ReadLine();
            Console.WriteLine("PersonalNumber:");
            var personalNumber = Console.ReadLine();

            var id = _mrGreenCustomerCreatoreFacade.CreateCustomer(firstName, lastName, address, personalNumber);
            Console.WriteLine(id);
        }

        private void ViewRedBetCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            var customer = _redBetCustomerCreatorFacade.ViewCustomer(Guid.Parse(id));
            var json = JsonConvert.SerializeObject(customer, Formatting.Indented);
            Console.WriteLine(json);
        }

        private void ViewMrGreenCustomer()
        {
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            
            var customer = _mrGreenCustomerCreatoreFacade.ViewCustomer(Guid.Parse(id));
            var json = JsonConvert.SerializeObject(customer, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
