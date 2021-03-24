using AndersenCoreApp.Infrastructure;
using AndersenCoreApp.Interfaces.Helpers;

namespace AndersenCoreApp.Helpers
{
    /// <inheritdoc />
    public class RelationHelpers : IRelationHelpers
    {
        /// <inheritdoc />
        public RelationFilter CreateRelationFilter(string filterByCategoryName, string sortByProperty, OrderBy orderBy)
        {
            return new RelationFilter(filterByCategoryName, sortByProperty, orderBy);
        }
    }
}
