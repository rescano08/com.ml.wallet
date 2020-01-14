using com.ml.api_wallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace com.ml.api_wallet.Controllers
{
    public class WalletController : ApiController
    {
        [HttpPost, AllowAnonymous, Route("api/wallet/registration")]
        public async Task<IHttpActionResult> Registration(WalletLogin walletLogin)
        {
            Result result = new Result();

            result.error = true;
            result.message = "Something went wrong!";
            result.data = "you can pass any object here";

            return Ok(await Task.Run(() => result));
        }

        [HttpPost, AllowAnonymous, Route("api/wallet/login")]
        public async Task<IHttpActionResult> Login(WalletLogin walletLogin)
        {
            Result result = new Result();

            result.error = true;
            result.message = "Something went wrong!";
            result.data = "you can pass any object here";

            return Ok(await Task.Run(() => result));
        }
    }
}
