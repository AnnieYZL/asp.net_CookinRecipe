using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class UserAccountService
    {
        private static readonly IUserAccountDAL userAccountDB;

        static UserAccountService()
        {
            userAccountDB = new UserAccountDAL(Configuration.ConnectionString);
        }

        public static UserAccount? Authorize(string userName, string password)
        {
            return userAccountDB.Authorize(userName, password);
        }

        public static bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return userAccountDB.ChangePassword(userName, oldPassword, newPassword);
        }

    }
}

