﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsWebApi
{
    public static class Extensions
    {
        public static bool IsAuthorized(this ControllerBase controller)
        {

            if (controller.Request.Headers.TryGetValue("Basic", out var token))
            {

                var keys = Base64Decode(token).Split('|');
                var _id = Convert.ToInt32(keys[1]);
                var date = Convert.ToDateTime(keys[2]);
                var min = Convert.ToInt32(keys[3]);

                if (date.AddMinutes(min) < DateTime.UtcNow)
                    return false;

            }

            return true;
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}