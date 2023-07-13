using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Solid
{
    internal class SingleResponsiblityPrinciple
    {
        private readonly IUser _user;

        public SingleResponsiblityPrinciple(IUser user)
        {
            _user = user;
        }
    }

    internal interface IUser
    {
        void Register(string name);
        void Unregister(string name);
    }

    internal interface ILogger
    {
        void Info(string message);
        void Warn(string message);
    }

    internal interface IEmail
    {
        void SendMail(string content);
    }

    internal class User : IUser
    {
        private readonly ILogger logger;

        public User(ILogger logger)
        {
            this.logger = logger;
        }

        public void Register(string name)
        {
            logger.Info(name);
        }

        public void Unregister(string name)
        {
            logger?.Info(name);
        }
    }

    internal class Logger : ILogger
    {
        public void Info(string message)
        {
            
        }

        public void Warn(string message)
        {
            
        }
    }

    internal class Email : IEmail
    {
        public void SendMail(string content)
        {
            
        }
    }
}
