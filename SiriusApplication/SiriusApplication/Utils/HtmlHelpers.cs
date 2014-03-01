using System.Web.Mvc;
using System.Web.Mvc.Html;

public static class HtmlHelpers
{
    public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
    {
        //TODO add active class to hobbies & interests nav link
        var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
        var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
        var htmlWithClass = "";
        var htmlWithNoClass = "<li><a href='/" + controllerName + "'>" + linkText + "</a></li>";

        if (controllerName == currentController && actionName == currentAction)
        {
            htmlWithClass = htmlWithNoClass.Insert(3, " class='active'");
            return new MvcHtmlString(htmlWithClass);
        }

        return new MvcHtmlString(htmlWithNoClass);
    }
}