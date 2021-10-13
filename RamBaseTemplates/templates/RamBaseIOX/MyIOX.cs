using System.Text;
using System.Threading.Tasks;
using RamBaseIOXRuntimeUtils;
using RamBaseIOXRuntimeUtils.Input;

namespace $safeprojectname$
{
    internal class MyIOX : IOXBase
    {
        public override async Task Run(IInputHandler input, IResultHandler result, IConfigurationManager configuration)
        {
            //Do something with the input
            StringBuilder sb = new();

            for (int i = 0; i < input["RTB"].Count; i++)
            {
                sb.Append(input["RTB"][i]["Name"]);
            }

            //Write to the output
            result.WriteOut(sb.ToString());

            //Set execution result
            result.WriteResult(ResultStatus.OK);
        }
    }
}