using System.Reflection;
using System.Text;
using DnsClient.Protocol;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Security.Utils;

public class HttpUtilResponse 
{
    public object? error {get; set;}
    public object? result {get; set;}
}

public class HttpUtils
{
    public static JsonResult CreateHttpResponse<T>(object? msg, int? code = null) 
    {
        var type = typeof(T);
        var json = new JsonResult(new {});
        if (type == typeof(OkResult)) {
            json.Value = new HttpUtilResponse {
                error = null,
                result = msg
            };
            json.StatusCode = 200;
        }

        if (type == typeof(BadRequestResult)) {
            json.Value = new HttpUtilResponse {
                error = msg,
                result = null
            };
            json.StatusCode = 400;
        }

        if (code != null) {
            json.Value = new HttpUtilResponse {
                error = msg,
                result = null
            };
            json.StatusCode = code;
        }
        return json;
    }

    public static Username DecodeBasicAuth(string token)
    {
        string encodedUserName = token.Substring("Basic ".Length).Trim();
        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        string userpws = encoding.GetString(Convert.FromBase64String(encodedUserName));

        int sep = userpws.IndexOf(':');

        return new Username {
            user = userpws.Substring(0, sep),
            password = userpws.Substring(sep+1)
        };
    }
}