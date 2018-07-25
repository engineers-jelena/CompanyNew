using CompanyNew.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;



namespace CompanyNew.Controllers
{
    public class BaseController : ApiController
    {
        private CompanyManager companyManager;
        protected CompanyManager CompanyManager => companyManager ?? (companyManager = new CompanyManager());


        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }
    }
}