using AndersenCoreApp.Interfaces.Formatters;
using AndersenCoreApp.Models.DTO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AndersenCoreApp.Infrastructure.Formatters
{
    /// <inheritdoc />
    public class PostalCodeFormatter : IPostalCodeFormatter
    {
        /// <inheritdoc />
        public RelationDTO ApplyPostalCodeMask(RelationDTO relation, string postalCodeFormat, string postalCode)
        {
            if (CheckPostalMask(postalCodeFormat, postalCode))
            {
                relation.PostalCode = FormatPostalCode(postalCodeFormat, postalCode);
            }
            return relation;
        }

        /// <inheritdoc />
        public bool CheckPostalMask(string postalCodeFormat, string postalCode)
        {
            if (!string.IsNullOrEmpty(postalCodeFormat))
            {
                var regularExpression = CreateRegularExpression(postalCodeFormat);
                var regEx = new Regex(regularExpression, RegexOptions.IgnoreCase);
                return regEx.IsMatch(postalCode);
            }
            return false;
        }

        /// <inheritdoc />
        public string CreateRegularExpression(string postalCodeFormat)
        {
            var postalCodeChars = postalCodeFormat.ToCharArray();
            var sb = new StringBuilder(@"^");
            foreach (var c in postalCodeChars)
            {
                switch (c)
                {
                    case 'N':
                        sb.Append(@"\d");
                        break;
                    case 'L':
                        sb.Append("[A-Z]");
                        break;
                    case 'l':
                        sb.Append("[a-z]");
                        break;
                    case '-':
                        sb.Append(@"\-?");
                        break;
                }

            }
            sb.Append("$");
            var regularExpression = sb.ToString();
            return regularExpression;
        }

        /// <summary>
        /// Formats postal code according to the format
        /// </summary>
        /// <returns>Returns formatted postal code</returns>
        private string FormatPostalCode(string postalCodeFormat, string postalCode)
        {
            StringBuilder sb = new StringBuilder("");
            int postalCodeSkipedChars = 0;

            for (int i = 0; i < postalCodeFormat.Count(); i++)
            {
                char currentPostalCodeChar = postalCode.Skip(postalCodeSkipedChars).FirstOrDefault();
                var currentFormatChar = postalCodeFormat[i];
                if (currentFormatChar == 'N')
                {
                    sb.Append(currentPostalCodeChar);
                    postalCodeSkipedChars++;
                }
                if (currentFormatChar == 'l')
                {
                    sb.Append(char.ToLower(currentPostalCodeChar));
                    postalCodeSkipedChars++;
                }
                if (currentFormatChar == '-')
                {
                    if (!char.Equals(currentPostalCodeChar, '-'))
                    {
                        sb.Append(currentFormatChar);

                    }
                }
                if (currentFormatChar == 'L')
                {
                    sb.Append(char.ToUpper(currentPostalCodeChar));
                    postalCodeSkipedChars++;
                }
            }
            return sb.ToString();
        }
    }
}
