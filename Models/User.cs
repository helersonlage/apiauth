namespace apiauth.Model
{
    public class User
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        //In a real context the password should be encrypted and not exposed
        public string Password { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

    }
}
