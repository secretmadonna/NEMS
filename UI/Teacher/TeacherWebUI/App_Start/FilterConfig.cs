using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new CustomHandleErrorAttribute());
            filters.Add(new CustomActionFilterAttribute());
            //filters.Add(new ParameterActionFilterAttribute());
        }
    }
}