using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpContextAccessor _hca;
        public string CookieContent { get; set; }    

        public IndexModel(ILogger<IndexModel> logger , IHttpContextAccessor hca)
        {
            _logger = logger;
            _hca = hca;
            var r = _hca.HttpContext.Request;
            if (r.Cookies["K"] != null)
                CookieContent = r.Cookies["K"];
            else
                CookieContent = "nic";
            
        }

        public void OnGet(string content)
        {
            if (!String.IsNullOrEmpty(content))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                };
                _hca.HttpContext.Response.Cookies.Append("K", content, cookieOptions);
            }
               
        }
    }
}
