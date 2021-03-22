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

        //Move to Enum folder and separate file
        public enum OrderBy
        {
            Default = 0,
            Ascending,
            Descending
        }

        public OrderBy Order { get; }

        public string FilterByCategoryName { get; }

        public string SortByProperty { get; }
    }
}
