using Inspinia_MVC5.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Linq;
using System.Collections.Generic;
using System.Web.Routing;

namespace Inspinia_MVC5.CustomAttributes
{
    public class BasicAuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool _authenticate;
        public string Roles;
        private readonly string[] allowedroles;

        public BasicAuthAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            _authenticate = (filterContext.ActionDescriptor.GetCustomAttributes(
                typeof(OverrideAuthenticationAttribute), true).Length == 0);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private Modelo context = new Modelo();

        //private readonly string[] allowedroles;
        //public CustomAuthorizeAttribute(params string[] roles)
        //{
        //    this.allowedroles = roles;
        //}

        private readonly string allowedroles;
        public CustomAuthorizeAttribute(string _transaccion)
        {
            this.allowedroles = _transaccion;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            if (httpContext.User.Identity.IsAuthenticated == true)
            {
                string _usuario = httpContext.User.Identity.Name;

                List<UsuarioRol> usuarioRoles = context.Usuario.Where(x => x.Usuario1 == _usuario).FirstOrDefault()
                                                        .UsuarioRol.Where(x => x.Estado == 1).ToList();

                foreach (UsuarioRol role in usuarioRoles)
                {
                    var transaccion = context.RolTransaccion
                                        .Where(x => x.IdRol == role.IdRol && x.Estado == 1)
                                        .Where(x => x.Transaccion.Nombre == allowedroles && x.Estado == 1).ToList();

                    if (transaccion.Count() > 0)
                    {
                        authorize = true;
                        break;
                    }
                }
            }

            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary 
                                        {
                                            { "action", "NoTieneAcceso" },
                                            { "controller", "Dashboards" },
                                            { "parameterName", "" }
                                        }
                                    );
        }
    }
}
