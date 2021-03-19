namespace AndersenCoreApp.Infrastructure
{
    public class RelationFilter
    {
        public enum OrderBy
        {
            Ascending,
            Descending
        }

        public OrderBy Order { get; }

        public readonly string filterByCategoryName;
        public readonly string sortByProperty;

        public RelationFilter(string category, string property, OrderBy order)
        {
            filterByCategoryName = category;
            sortByProperty = property;
            Order = order;
        }
    }
}
