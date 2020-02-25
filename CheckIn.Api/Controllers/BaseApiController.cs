using System.Web.Http;
using CheckIn.Class;

namespace CheckIn.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public Profile Profile { get; set; }


    }
}