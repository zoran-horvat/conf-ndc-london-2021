namespace Demo.Models.Authentication
{
    public class UserRef
    {
        public string Value { get; }

        public UserRef(string value)
        {
            this.Value = value;
        }

        public static UserRef Empty => new UserRef(string.Empty);
    }
}
