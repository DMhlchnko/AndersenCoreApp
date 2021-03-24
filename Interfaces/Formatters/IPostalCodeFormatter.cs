using AndersenCoreApp.Models.DTO;

namespace AndersenCoreApp.Interfaces.Formatters
{
    /// <summary>
    /// Postal code formatter interface
    /// </summary>
    public interface IPostalCodeFormatter
    {
        /// <summary>
        /// Checks postal code matching with postal code mask
        /// </summary>
        bool CheckPostalMask(string postalCodeFormat, string postalCode);

        /// <summary>
        /// Creates regular expression from postal code format
        /// </summary>
        string CreateRegularExpression(string postalCodeFormat);

        /// <summary>
        /// Applies postal code format
        /// </summary>
        RelationDTO ApplyPostalCodeMask(RelationDTO relation, string postalCodeFormat, string postalCode);
    }
}
