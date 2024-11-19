using Entities;
using Microsoft.AspNetCore.Mvc;
using Security.Utils;

[Route("api/encrypt")]
[ApiController]
public class EncryptionController : ControllerBase
{
    [HttpPost]
    public ActionResult EncryptString(EncryptQuery query)
    {
        return HttpUtils.CreateHttpResponse<OkResult>(
            SecurityUtils.HashString(query.encode!)
        );
    }

    [HttpPost("decode")]
    public ActionResult DecodeString(EncryptQuery query)
    {
        return HttpUtils.CreateHttpResponse<OkResult>(
            SecurityUtils.HashString(query.decode!)
        );
    }
}