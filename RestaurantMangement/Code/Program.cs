using RestaurantMangement.Code.Model;

namespace RestaurantMangement.Code
{
    internal static class Program
    {

        public static Account currentAcc = new Account();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FResLogin());
        }
    }
}