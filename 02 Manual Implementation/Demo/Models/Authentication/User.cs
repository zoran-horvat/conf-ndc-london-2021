namespace Demo.Models.Authentication
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Key { get; private set; }

        public UserRef Reference 
        { 
            get => new UserRef(this.Key); 
            private set => this.Key = value.Value; 
        }

        public User(int id, string userName, UserRef reference)
        {
            this.Id = id;
            this.UserName = userName;
            this.Reference = reference;
        }

        private User() : this(0, string.Empty, UserRef.Empty) { }

        public override string ToString() => UserName;
    }
}
