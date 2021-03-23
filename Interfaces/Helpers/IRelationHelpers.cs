using AndersenCoreApp.Infrastructure;

namespace AndersenCoreApp.Interfaces.Helpers
{
    /// <summary>
    /// Relation helpers interface
    /// </summary>
    public interface IRelationHelpers
    {
        /// <summary>
        /// Creates Relation Filter
        /// </summary>
        /// <returns>Relation filter</returns>
        RelationFilter CreateRelationFilter(string filterByCategoryName, string sortByProperty, OrderBy orderBy);
    }
}
