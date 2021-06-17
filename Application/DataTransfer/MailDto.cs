using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class MailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
