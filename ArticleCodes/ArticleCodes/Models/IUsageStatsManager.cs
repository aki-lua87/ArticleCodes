using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCodes.Models
{
    public interface IUsageStatsManager
    {
        string GetAppName();
        string GetType();
        string GetTestA();
        string GetTestB();
        string GetTestC();
        string GetTestD();
    }
}
