﻿using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string url { get; set; }
        public object? Data { get; set; } = true;
        public string AccessToken { get; set; } = "";
    }
}
