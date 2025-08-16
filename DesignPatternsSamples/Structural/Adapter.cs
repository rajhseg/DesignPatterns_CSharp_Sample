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

    public class LegacyDBWriter
    {
        public void WriteToDB(string message)
        {

        }
    }

    public class DBAdapter : ILogger
    {
        LegacyDBWriter writer;

        public DBAdapter()
        {
            writer = new LegacyDBWriter();
        }

        public void Log(string message)
        {
            writer.WriteToDB(message);
        }
    }

    public class CliSystem
    {
        private readonly ILogger logger;


        public CliSystem(ILogger logger)
        {
            this.logger = logger;
        }

        public void Exec(string message)
        {
            this.logger.Log(message);
            this.logger.Log("sample1");
        }
    }

    public class Employee : IEmployee
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string GetDetails(int indent)
        {
            return new string('-', indent) + Name;
        }
    }
}
