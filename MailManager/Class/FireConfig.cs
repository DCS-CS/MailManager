using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager.Class
{
    class FireConfig
    {
        public static FirebaseClient GetClient()
        {
            string auth = "fHpWjVWQYzXVy4nwZpqmpvkMySYzRM9I4csjFWAt";
            string url = "https://mailmanager-49f1c.firebaseio.com";
            return new FirebaseClient(
                    url,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(auth)
                    });
        }

        public static FirebaseAuthProvider GetAuthProvider()
        {
            string auth2 = "AIzaSyCX0f-fX3B1EWpUtGWuF-WEzebQihg3H-E";
            return new FirebaseAuthProvider(new FirebaseConfig(auth2));
        }
    }
}
