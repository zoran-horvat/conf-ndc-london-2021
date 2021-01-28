using Demo.Models.Authentication;

namespace Demo.Models.Content
{
    public class FriendConnection
    {
        public int Id { get; private set; }
        public string OwnerKey { get; private set; }
        public string FriendKey { get; private set; }
        public UserRef Owner => new UserRef(this.OwnerKey);
        public UserRef Friend => new UserRef(this.FriendKey);

        private FriendConnection() : this(0, UserRef.Empty, UserRef.Empty)
        {
        }

        public FriendConnection(int id, UserRef owner, UserRef friend)
        {
            this.Id = id;
            this.OwnerKey = owner.Value;
            this.FriendKey = friend.Value;
        }
    }
}
