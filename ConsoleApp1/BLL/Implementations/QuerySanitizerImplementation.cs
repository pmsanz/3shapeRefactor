using LibraryConsoleApp.BLL.Interfaces;

namespace LibraryConsoleApp.BLL.Implementations
{
    public class QuerySanitizerImplementation : IQuerySanitizer
    {
        public List<string> SanitizeQueryText(string searchString)
        {
            List<string> sanitizedList = new List<string>();
            bool hasLiteral = searchString.Contains(@"\&");

            if (hasLiteral)
            {
                int j = 0;
                for (int i = 0; i < searchString.Length; i++)
                {
                    if (i > 0 && searchString[j] != '\\' && searchString[i] == '&')
                    {
                        sanitizedList.Add(searchString.Substring(0, i));
                        searchString = searchString.Remove(0, i + 1);
                        i = 0;
                        j = 0;
                    }
                    j = i > 0 ? i : 0;
                }
                if (searchString.Length > 0)
                    sanitizedList.Add(searchString);
            }
            else
            {
                sanitizedList = searchString.Split('&').ToList();
            }
            for (int i = 0; i < sanitizedList.Count; i++)
            {
                if (string.IsNullOrEmpty(sanitizedList[i]))
                    continue;
                string query = sanitizedList[i];
                query = query.Replace(@"\&", "&");
                query = query.Trim().Remove(0, 1);
                query = query.Remove(query.Length - 1, 1);
                sanitizedList[i] = query;
            }

            return sanitizedList;
        }
    }
}
