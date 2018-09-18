using System;
using System.Collections.Generic;
using System.Text;

namespace Paycor.MarketPlace.ApiClient.Models
{
    public class QueryStringParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string QueryStringName { get { return Name.ToLower(); } }

        /// <summary>
        /// Initializes a new instance of the Paycor.MarketPlace.ApiClient.Models.QueryStringParameter class to the value indicated
        /// by the specified string name and string value.
        /// </summary>
        /// <param name="name">String name of the QueryStringParameter</param>
        /// <param name="value">String value of the QueryStringParameter.</param>
        public QueryStringParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the Paycor.MarketPlace.ApiClient.Models.QueryStringParameter class to the value indicated
        /// by the specified CommonQueryStringNames and string value.
        /// </summary>
        /// <param name="name">CommonQueryStringNames value.  Will be used for the name of the QueryStringParameter.</param>
        /// <param name="value">String value of the QueryStringParameter.</param>
        public QueryStringParameter(CommonQueryStringNames name, string value)
        {
            Name = name.ToString();
            Value = value;
        }
    }

    /// <summary>
    /// These are common parameter names used in Paycor query strings
    /// </summary>
    public enum CommonQueryStringNames
    {
        Page,
        PageSize,
        Sort,
        ClientId,
        ObjectSize
    }
}
