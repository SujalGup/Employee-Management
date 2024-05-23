using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Task1.AppCode
{
    public static class IHtmlHelpers
    {
        public static HtmlString DisplayEmployeeStatus(this IHtmlHelper helper, string status)
        {
            if (status == Constants.Active)
            {
                return new HtmlString($"<span class='badge badge-pill badge-success'>{status}</span>");
            }
            else
            {
                return new HtmlString($"<span class='badge badge-pill badge-danger'>{status}</span>");

            }

        }
        public static HtmlString DisplayReportStatus(this IHtmlHelper helper, string status)
        {
            if (status == Constants.Complete)
            {
                return new HtmlString($"<span class='badge badge-pill badge-success'>{status}</span>");
            }
            else if (status == Constants.InComplete)
            {
                return new HtmlString($"<span class='badge badge-pill badge-warning'>{status}</span>");
            }
            else
            {
                return new HtmlString($"<span class='badge badge-pill badge-danger'>{status}</span>");

            }

        }

            public static HtmlString DisplayCategoryMandatory(this IHtmlHelper helper, string mandatory)
        {
            if (mandatory == Constants.Yes)
            {
                return new HtmlString($"<span class='badge badge-pill badge-success'>{mandatory}</span>");
            }
            else
            {
                return new HtmlString($"<span class='badge badge-pill badge-danger'>{mandatory}</span>");

            }

        }

        public static HtmlString DisplayDate(this IHtmlHelper helper, DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return new HtmlString(String.Empty);
            }
            else 
            { 
                return new HtmlString(date.ToString("MMM dd, yyyy"));
            
            }
        }
    }


}
                       
