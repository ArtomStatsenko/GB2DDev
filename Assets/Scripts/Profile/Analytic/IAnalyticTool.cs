using System.Collections.Generic;

namespace Profile.Analytic
{
    internal interface IAnalyticTool
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}
