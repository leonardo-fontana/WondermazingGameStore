using System.Web;
using System.Web.Mvc;

namespace WondermazingGameStore.UserAccount.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
