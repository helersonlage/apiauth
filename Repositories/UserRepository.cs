using apiauth.Model;

namespace apiauth.Repositories
{
    public class UserRepository
    {

        /// <summary>
        ///  Get User
        /// </summary>
        /// <param name="username"> user name</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public static User? Get(string username, string password)
        {

            var users = GetData();

            return users.FirstOrDefault(u => u.Name == username && u.Password == password);

        }


        /// <summary>
        ///   Get Users Data 
        ///   Database access not implemented, not in the scope of this lab
        /// </summary>        
        private static List<User> GetData()
        {

            return new List<User>() {

                new User(){ UserId = 1, FullName= "Eric Clapton", Name = "Eric@Clapton", Password ="qwertClapton", Role="Guitarrist" },
                new User(){ UserId = 2, FullName= "Bono Vox", Name = "Bono@Vox", Password ="qwertyVox", Role="Vocalist" },
                new User(){ UserId = 2, FullName= "Helerson Lage", Name = "Helerson@Lage", Password ="qwertyLage", Role="Guitarrist" },

            };

        }

    }
}
