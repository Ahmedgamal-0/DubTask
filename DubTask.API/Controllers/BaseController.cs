using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DubTask.API.Controllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    [ApiVersion("1.0")]
    public abstract class BaseController: ControllerBase
    {
        protected internal const string BasePath = "api/dubTask";
        private IMediator _mediatorInstance;
        protected string LastUpdatedBy;
        protected IMediator Mediator
        {
            get
            {

                var mediator = _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
                InitiateOnMediatorRequest();
                return mediator;
            }
        }
        protected IMediator UnAuthorizedMediator
        {
            get
            {

                var mediator = _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
                return mediator;
            }
        }
        #region Constructor(s)
        public BaseController()
        {

        }
        #endregion
        void InitiateOnMediatorRequest()
        {
            //Microsoft.Extensions.Primitives.StringValues token;
            //Request.Headers.TryGetValue("Authorization", out token);
            //LastUpdatedBy = JwtTokenHelper.ExtractUserIdFromToken(token);
        }
    }
}
