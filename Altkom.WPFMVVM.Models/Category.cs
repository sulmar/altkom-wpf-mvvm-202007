namespace Altkom.WPFMVVM.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        // Singleton
        private static Category all;
        public static Category All
        {
            get
            {
                if (all == null)
                {
                    all = new Category { Id = -1, Name = "All" };
                }

                return all;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Category);
        }

        public static bool operator ==(Category lc, Category rc)
        {
            if (object.ReferenceEquals(lc, null))
            {
                if (object.ReferenceEquals(rc, null))
                {
                    return true;
                }

                return false;
            }

            return lc.Equals(rc);
        }

        public static bool operator!=(Category lc, Category rc)
        {
            return !(lc == rc);
        }

        public override int GetHashCode()
        {
            var hash = Name.GetHashCode();
            return hash;
        }
        private bool Equals(Category category)
        {
            return this.Name == category?.Name;
        }

    }
}
