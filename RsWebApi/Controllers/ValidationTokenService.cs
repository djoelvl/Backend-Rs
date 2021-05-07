using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RedSocial.Services
{
    [ApiController]
    public class ValidationTokenService : ControllerBase
    {
//        public static string Base64Decode(string base64EncodedData)
//        {
//            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
//            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
//        }

//        public async Task<IActionResult> ValidationToken(int id) { 
//        if (Request.Headers.TryGetValue("Basic", out var token))
//            {
                
//                var keys = Base64Decode(token).Split('|');
//        var _id = Convert.ToInt32(keys[1]);
//        var date = Convert.ToDateTime(keys[2]);
//        var min = Convert.ToInt32(keys[3]);

//                if (date.AddMinutes(min) < DateTime.UtcNow && _id == id)
//                    return  Unauthorized();

                
//    }
//        return  Ok();
//}
}
}
