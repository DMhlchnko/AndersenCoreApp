namespace AndersenCoreApp.Infrastructure
{
    public class RelationFilter
    {
        public RelationFilter(string filterByCategoryName, string sortByProperty, OrderBy order)
        {
            FilterByCategoryName = filterByCategoryName;
            SortByProperty = sortByProperty;
            Order = order;
        }
 
        public OrderBy Order { get; }

        public string FilterByCategoryName { get; }

        public string SortByProperty { get; }
    }
}
