using Demo.Models.Authentication;

namespace Demo.Models.Content
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string OwnerKey { get; private set; }

        public Product(int id, string name, UserRef owner)
        {
            this.Id = id;
            this.Name = name;
            this.OwnerKey = owner.Value;
        }

        private Product() : this(0, string.Empty, UserRef.Empty) { }

        public override string ToString() => Name;
    }
}
