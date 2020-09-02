using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace AdminMaster.UI.Filters
{
    public class AuthenticateFilter : AuthorizeAttribute
    {
        private string _loginUrl = string.Empty;
        public AuthenticateFilter(string loginUrl = "~/Authenticate/Login")
        {
            _loginUrl = loginUrl;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var context = filterContext.HttpContext;
            if (filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true))
            {
                return;
            }
            else if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            else if (context.Session["CurrentUser"] != null && context.Session["CurrentUser"] is UserViewModel)
            {
                return;
            }
            else
            {
                if (context.Request.IsAjaxRequest())
                {
                    AjaxResult ajaxResult = new AjaxResult()
                    {
                        Result = DoResult.NoAuthorization,
                        PromptMsg = "没有登陆，无权访问"
                    };
                    filterContext.Result = new JsonResult
                    {
                        Data = ajaxResult
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult(_loginUrl);
                    //打开A页面--没有登陆---跳转到登陆页---希望登陆后，再跳到刚才的页面
                    context.Session["CurrentUrl"] = context.Request.Url;
                }
            }
        }
    }

    public sealed class CustomAllowAnonymousAttribute : Attribute
    {

    }
}