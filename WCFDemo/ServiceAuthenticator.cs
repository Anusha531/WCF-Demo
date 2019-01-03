using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace WCFDemo
{
    public class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            // Check the user name and password
            if (userName != "Anusha" || password != "Anusha")
            {
                throw new SecurityTokenException("Unknown username or password.");
            }
        }
    }
}