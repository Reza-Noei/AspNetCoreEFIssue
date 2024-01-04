namespace AspNetCoreEF
{
    public class User
    {
        protected User()
        {

        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int Id { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }
    }
}