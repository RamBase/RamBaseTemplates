using System;
using System.Threading.Tasks;
using RamBaseIOXRuntimeUtils;

namespace $safeprojectname$
{
    public class Program
    {
        //You should not have to do any changes in this file. The IOX should be implemented in MyIOX.cs
        static async Task Main(string[] args)
        {
            //Setup IOX runtime then run the IOX.
            await new IOXRuntimeBuilder(args).Run<MyIOX>();
        }
    }
}