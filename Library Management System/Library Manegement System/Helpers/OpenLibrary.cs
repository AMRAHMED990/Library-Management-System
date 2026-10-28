using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Library_Manegement_System
{
    public class BookInfo
    {
        public string Title = "";
        public string Author = "";
        public string Publisher = "";
    }

    // Networking: get book details from openlibrary.org by ISBN
    public static class OpenLibrary
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<BookInfo> FindBookAsync(string isbn)
        {
            string url = "https://openlibrary.org/api/books?bibkeys=ISBN:" + isbn + "&format=json&jscmd=data";
            string json = await client.GetStringAsync(url);

            // the reply looks like { "ISBN:978...": { "title": ..., "authors": [{ "name": ... }] } }
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(json);
            if (!result.ContainsKey("ISBN:" + isbn))
                return null;

            Dictionary<string, object> book = result["ISBN:" + isbn];
            BookInfo info = new BookInfo();
            if (book.ContainsKey("title")) info.Title = book["title"].ToString();
            info.Author = FirstName(book, "authors");
            info.Publisher = FirstName(book, "publishers");
            return info;
        }

        private static string FirstName(Dictionary<string, object> book, string key)
        {
            if (!book.ContainsKey(key)) return "";
            IList list = book[key] as IList;
            if (list == null || list.Count == 0) return "";
            Dictionary<string, object> first = list[0] as Dictionary<string, object>;
            return first != null && first.ContainsKey("name") ? first["name"].ToString() : "";
        }
    }
}
