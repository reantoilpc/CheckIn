using System.Web.Http;
using CheckIn.Class;

namespace CheckIn.Api.Controllers
{
    /// <summary>
    /// API 基底類別
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        /// <summary>
        ///     使用者資料
        /// </summary>
        public Profile Profile { get; set; }
    }
}