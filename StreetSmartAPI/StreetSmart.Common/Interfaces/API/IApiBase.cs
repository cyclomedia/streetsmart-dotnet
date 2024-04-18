using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StreetSmart.Common.Interfaces.API
{
    internal interface IApiBase
    {
        void RegisterThisJsObject();
        Task<object> CallJsGetScriptAsync(string script, [CallerMemberName] string memberName = "");
        string GetScript(string funcName, int processId = 0, [CallerMemberName] string memberName = "");
        string AddTryCatch(string script, string funcName);
        Task<object> CallJsAsync(string script, int processId, [CallerMemberName] string memberName = "");
    }
}
