using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace WebUI._1._0.Core.Service
{
    public class EmailService : IIdentityMessageService
    {        
        public Task SendAsync(IdentityMessage message)
        {
            //var client = SendGridClient(ConfigurationManager.AppSettings[""]);
            //var from = new EMailAddress("vije1n12000@gmail.com");
            //var to = new EMailAddress("vijeder.kumar@icreon.com");
            //Send Email
            throw new NotImplementedException();
        }
    }
}