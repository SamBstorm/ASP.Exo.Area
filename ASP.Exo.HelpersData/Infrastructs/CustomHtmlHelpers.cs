using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Exo.HelpersData.Infrastructs
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString Toast(this HtmlHelper html, string message, bool IsSuccessfull)
        {
            TagBuilder mainDiv = new TagBuilder("div");
            if (IsSuccessfull)
            {
                mainDiv.MergeAttribute("style", "background-color :limegreen;position : absolute;top: 20px;border-radius:15px;z-index: 9999;min-width: 256px;text-align: center;vertical-align: middle;");
            }
            else
            {
                mainDiv.MergeAttribute("style", "background-color :red;position : absolute;top: 20px;border-radius:15px;z-index: 9999;min-width: 256px;text-align: center;vertical-align: middle;");
            }
            TagBuilder mainText = new TagBuilder("p");
            mainText.MergeAttribute("style", "color: white; padding: 10px;");
            mainText.SetInnerText(message);
            mainDiv.InnerHtml = mainText.ToString();
            return new MvcHtmlString(mainDiv.ToString());
        }
    }
}