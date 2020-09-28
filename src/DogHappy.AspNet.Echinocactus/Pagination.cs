using System;
using System.Text;

namespace DogHappy.AspNet.Echinocactus
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Create pagination, default page size is 20.
        /// </summary>
        /// <param name="page">Page index</param>
        public Pagination(int page)
        {
            Page = page;
        }

        /// <summary>
        /// Create pagination
        /// </summary>
        /// <param name="page">Page index</param>
        /// <param name="size">Page size</param>
        public Pagination(int page, int size) : this(page)
        {
            Size = size;
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The value is related to ToalItems
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / Size);

        /// <summary>
        /// Page size, default is 20.
        /// </summary>
        public int Size { get; set; } = 20;

        /// <summary>
        /// Page index, start with 1.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Previous text, default is «(&amp;laquo;)
        /// </summary>
        public string PreviousText { get; set; } = "&laquo;";

        /// <summary>
        /// Previous text, default is »(&amp;raquo;)
        /// </summary>
        public string NextText { get; set; } = "&raquo;";

        /// <summary>
        /// Display the page number of the first page, if the value is set.
        /// </summary>
        public string FirstPageText { get; set; }

        /// <summary>
        /// Display the page number of the last page, if the value is set.
        /// </summary>
        public string LastPageText { get; set; }

        /// <summary>
        /// In the last item of the page bar, Appen is displayed in the style of the page number.
        /// </summary>
        public string Append { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public string GetPageNumberLinks(Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<nav><ul class=\"pagination\">");
            if (Page > 1)
            {
                builder
                   .Append("<li class=\"page-item\"><a class=\"page-link\" href=\"")
                   .Append(pageUrl(Page - 1))
                   .Append("\">")
                   .Append(PreviousText)
                   .Append("</a></li>");
                if (FirstPageText != null)
                {
                    builder
                        .Append("<li class=\"page-item\"><a class=\"page-link\" href=\"")
                        .Append(pageUrl(1))
                        .Append("\">")
                        .Append(FirstPageText)
                        .Append("</a></li>");
                }
            }
            for (int i = 1; i <= TotalPages; i++)
            {
                if (Page == i)
                    builder
                        .Append("<li class=\"page-item active\"><span class=\"page-link\">")
                        .Append(i)
                        .Append("</span></li>");
                else
                    builder.Append("<li class=\"page-item\"><a class=\"page-link\" href=\"")
                        .Append(pageUrl(i))
                        .Append("\">")
                        .Append(i)
                        .Append("</a></li>");
            }
            if (Page < TotalPages)
            {
                builder
                    .Append("<li class=\"page-item\"><a class=\"page-link\" href=\"")
                    .Append(pageUrl(Page + 1))
                    .Append("\">")
                    .Append(NextText)
                    .Append("</a></li>");
                if (LastPageText != null)
                {
                    builder
                        .Append("<li class=\"page-item\"><a class=\"page-link\" href=\"")
                        .Append(pageUrl(TotalPages))
                        .Append("\">")
                        .Append(LastPageText)
                        .Append("</a></li>");
                }
            }
            if (Append != null)
            {
                builder
                    .Append("<li class=\"page-item\"><span class=\"page-link\">")
                    .Append(Append)
                    .Append("</span></li>");
            }
            builder.Append("</ul></nav>");
            return builder.ToString();
        }
    }
}
