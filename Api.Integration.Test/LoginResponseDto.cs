using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        public bool authenticated { get; set; }
        public DateTime created { get; set; }
        public DateTime expiration { get; set; }
        public string accessToken { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string message { get; set; }

    }
}
