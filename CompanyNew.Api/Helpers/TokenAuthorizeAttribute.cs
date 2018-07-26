using CompanyNew.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace CompanyNew.Api.Helpers
{
    public class TokenAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the roles the user is in.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public string Roles { get; set; }

        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <exception cref="AuthenticationException">
        /// No Authorization header present
        /// or
        /// Authorization header cannot be empty
        /// or
        /// Invalid token!
        /// or
        /// Token expired! Please, login again
        /// or
        /// You do not have permission to access this resource!
        /// </exception>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Skip validation if AllowAnonymous attribute is set
            if (!SkipValidation(actionContext))
            {
                // Check for authorization header
                var authorizationHeader = actionContext.Request.Headers.FirstOrDefault(h => h.Key == "Authorization");
                if (authorizationHeader.Key == null)
                {
                    throw new AuthenticationException("No Authorization header present");
                }

                // Get token from Authorization header
                string tokenString = authorizationHeader.Value.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(tokenString))
                {
                    throw new AuthenticationException("Authorization header cannot be empty");
                }

            }

            base.OnActionExecuting(actionContext);
        }

        private bool SkipValidation(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}