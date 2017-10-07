using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Authorization;

namespace CIbertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    public class BaseController : Controller
    {
        protected IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}