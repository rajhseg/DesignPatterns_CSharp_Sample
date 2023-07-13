using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Solid
{
    internal class DependencyInversionPrinciple
    {
        private readonly ILogger logger;

        public DependencyInversionPrinciple(ILogger logger)
        {
            this.logger = logger;
        }

        public void Process()
        {
            this.logger.Info("sample");
            this.logger.Warn("sample1");
        }
    }
}
