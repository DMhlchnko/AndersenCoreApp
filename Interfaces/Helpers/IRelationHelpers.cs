using AndersenCoreApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
