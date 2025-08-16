using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Structural
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class DBWriter
    {
        public void WriteToDB(string message)
        {

        }
    }

    public class DBAdapter : ILogger
    {
        DBWriter writer;

        public DBAdapter()
        {
            writer = new DBWriter();
        }

        public void Log(string message)
        {
            writer.WriteToDB(message);
        }
    }

    public class Employee
    {
        private readonly ILogger logger;

        public Employee(ILogger logger)
        {
            this.logger = logger;
        }

        public void Exec(string message)
        {
            this.logger.Log(message);
            this.logger.Log("sample1");
        }
    }
}
