using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyMVC3.Services
{
    public interface IMessageService
    {
        string GetMessage();
    }

    public class MessageService : IMessageService
    {
        #region IMessageService Members

        public string GetMessage()
        {
            return "Hello Controller!";
        }

        #endregion
    }
}