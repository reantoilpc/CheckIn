using System.Web.Http;
using CheckIn.Class;

namespace CheckIn.Api.Controllers
{
    public class ApiControllerBase : ApiController
    {
        /// <summary>
        /// 使用者資料
        /// </summary>
        public Profile Profile { get; set; }
    }
}