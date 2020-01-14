
using com.ml.api_wallet.Models;

namespace com.ml.api_wallet.Services
{
    public class WalletService
    {
        // add connection string variable

        public WalletService()
        {
            // connection string initilization
        }

        public Wallet ValidateUser(string email, string password)
        {
            // Here you can write the code to validate
            // User from database and return accordingly
            // To test we use dummy list here
            // status here only approved
            
            return null;

        }
    }
}