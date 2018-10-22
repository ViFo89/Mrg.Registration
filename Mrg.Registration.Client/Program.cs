using Mrg.Registration.WebApiFacade;

namespace Mrg.Registration.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiDependency = BootstrapWebApi();

            new RegistrationProgram(new MrGreenCustomerCreatorFacade(apiDependency), new RedBetCustomerCreatorFacade(apiDependency))
                .Run();
        }

        private static ICustomerWebApi BootstrapWebApi()
        {
            var api = new CustomerWebApi(new FakeRepository());
            return api;
        }
    }
}
