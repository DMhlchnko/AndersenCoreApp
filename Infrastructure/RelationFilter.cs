namespace AndersenCoreApp.Infrastructure
{
    /// <summary>
    /// Class for filtering relations
    /// </summary>
    public class RelationFilter
    {
        /// <summary>
        /// Constructor that initialize filter properties
        /// </summary>
        public RelationFilter(string filterByCategoryName, string sortByProperty, OrderBy order)
        {
            FilterByCategoryName = filterByCategoryName;
            SortByProperty = sortByProperty;
            Order = order;
        }

        /// <summary>
        /// Represents an order of sorting
        /// </summary>
        public OrderBy Order { get; }

        /// <summary>
        /// Represents a cotegory of filtration
        /// </summary>
        public string FilterByCategoryName { get; }

        /// <summary>
        /// Represents a propery to sort
        /// </summary>
        public string SortByProperty { get; }
    }
}
