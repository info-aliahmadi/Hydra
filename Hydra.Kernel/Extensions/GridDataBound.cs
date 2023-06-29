using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;


namespace Hydra.Kernel.Extensions
{
    public class GridDataBound
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        private string _sorting;
        public string Sorting { get; set; }
        private List<Sort>? SortingList => !string.IsNullOrEmpty(Sorting)
           ? JsonSerializer.Deserialize<List<Sort>>(Sorting)
           : new List<Sort>();

        public string GlobalFilter { get; set; }

        public string Filters { get; set; }

        private List<Filter>? FiltersList => !string.IsNullOrEmpty(Filters)
             ? JsonSerializer.Deserialize<List<Filter>>(Filters)
            : new List<Filter>();

        public List<string>? Conditions => FiltersList.Any() ? FiltersList?.Where(x => !string.IsNullOrEmpty(x.Condition)).Select(a => a.Condition).ToList() : new List<string>();
        public List<string>? Orders => SortingList.Any() ? SortingList?.Select(a => a.Order).ToList() : new List<string>();
    }
    public class Filter
    {
        public string id { get; set; }

        public string operation { get; set; }

        public object value { get; set; }

        public string Condition
        {
            get
            {
                switch (operation)
                {
                    case "contains":
                        return id + ".Contains(\"" + value + "\")";
                    case "notContains":
                        return "!" + id + ".Contains(\"" + value + "\")";
                    case "startsWith":
                        return id + ".StartsWith(\"" + value + "\")";
                    case "endsWith":
                        return id + ".EndsWith(\"" + value + "\")";
                    case "equals":
                        return id + " == \"" + value + "\"";
                    case "notEquals":
                        return id + " != \"" + value + "\"";
                    case "greaterThan":
                        return id + " > \"" + value + "\"";
                    case "greaterThanOrEqualTo":
                        return id + " >= \"" + value + "\"";
                    case "lessThan":
                        return id + " < \"" + value + "\"";
                    case "lessThanOrEqualTo":
                        return id + " <= \"" + value + "\"";
                    case "empty":
                        return id + " = NULL";
                    case "notEmpty":
                        return id + " != NULL";
                    case "between":
                        {
                            if (value.GetType() == typeof(JsonElement))
                            {
                                var valueArray = JsonSerializer.Deserialize<string[]>(value.ToString());
                                var res = !string.IsNullOrEmpty(valueArray[0]) ? 
                                                !string.IsNullOrEmpty(valueArray[1]) ?
                                                        (id + " >= " + valueArray[0] + " AND " + id + " <= " + valueArray[1]) : (id + " >= " + valueArray[0]) :
                                                !string.IsNullOrEmpty(valueArray[1]) ?
                                                        (id + " <= " + valueArray[1]) : "";
                                return res;
                            }
                            return id + " <= \"" + value + "\"";
                        }
                    case "betweenInclusive":
                        {
                            if (value.GetType() == typeof(JsonElement))
                            {
                                var valueArray = JsonSerializer.Deserialize<string[]>(value.ToString());
                                var res = !string.IsNullOrEmpty(valueArray[0]) && !string.IsNullOrEmpty(valueArray[1]) ?
                                                        (id + " < " + valueArray[0] + " OR " + id + " > " + valueArray[1]) :  "";
                                return res;
                            }
                            return id + " <= \"" + value + "\"";
                        }
                    default:
                        return id + ".Contains(\"" + value + "\")";
                }
            }
        }
    }

    public class Sort
    {
        public string id { get; set; }

        public bool desc { get; set; }

        public string Order
        {
            get
            {
                return id + (desc == true ? " DESC" : " ASC");
            }
        }
    }
}
