using Firebase.Auth;
using Firebase.Database;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.Class
{
    internal class UtilsMailManager
    {
        // Método para autenticarte en firebase y poder manipular el base de datos.
        public static FirebaseClient GetClient()
        {
            string auth = "Et3rlgfdp90t0txaEi6SqdF83blB4XUgp5amSJDH";
            string url = "https://mailmanager-6208b.firebaseio.com/";
            return new FirebaseClient(
                    url,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(auth)
                    });
        }
        // Método para autenticarte en firebase y obtener permiso para obtener el usuario de firebase.
        public static FirebaseAuthProvider GetAuthProvider()
        {
            string auth2 = "AIzaSyAfAxpnCMvIbffsQJEcpt0LAZa2K5HlzE4";
            return new FirebaseAuthProvider(new FirebaseConfig(auth2));
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
