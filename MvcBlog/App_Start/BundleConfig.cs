using System.Web;
using System.Web.Optimization;

namespace MvcBlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Styles/common").Include("~/Styles/common.css"));
            bundles.Add(new ScriptBundle("~/Scripts/common").Include("~/Scripts/common.js"));
        }
    }
}