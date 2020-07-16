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

}
}
