using System;
namespace webservapi.Models
{
    public class PushRequestModel
    {
            public string platform { get; set; }
            public string deviceToken { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public string body { get; set; }
            public int badge { get; set; }
            public string sound { get; set; }
        
    }
}
