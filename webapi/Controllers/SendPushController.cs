using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using webservapi.Models;

namespace webapi.Controllers
{
    public class SendPushController : ApiController
    {
        

        // POST: api/SendPush
        public IHttpActionResult Post(PushRequestModel req)
        {

            try
            {

                var headers = Request.Headers;
                if (!headers.Contains("api_key"))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)403,
                    new HttpError("API key bulunamadı")
                )
            );

                }

                string token = headers.GetValues("api_key").First();

                if(token != "test")
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
               Request.CreateErrorResponse(
                   (HttpStatusCode)401,
                   new HttpError("API key geçersiz")
               )
           );

                }

                if (String.IsNullOrEmpty(req.platform))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                                   Request.CreateErrorResponse(
                                       (HttpStatusCode)400,
                                       new HttpError("Lütfen platform belirtin")
                                   )
                               );
                }

                if (String.IsNullOrEmpty(req.deviceToken))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                                   Request.CreateErrorResponse(
                                       (HttpStatusCode)400,
                                       new HttpError("Lütfen deviceToken belirtin")
                                   )
                               );
                }

                if (String.IsNullOrEmpty(req.title))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                                   Request.CreateErrorResponse(
                                       (HttpStatusCode)400,
                                       new HttpError("Lütfen title belirtin")
                                   )
                               );
                }

                if (String.IsNullOrEmpty(req.body))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                                   Request.CreateErrorResponse(
                                       (HttpStatusCode)400,
                                       new HttpError("Lütfen body belirtin")
                                   )
                               );
                }


            }
            catch(Exception ex)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
               Request.CreateErrorResponse(
                   (HttpStatusCode)500,
                   new HttpError("Sunucu hatası, lütfen daha sonra deneyiniz.")
               )
           );
            }

      return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateResponse(
                    (HttpStatusCode) 200,
                    "SUCCESS"
                )
            );
            ;
        }
        

    }
}
