using System.Reflection;

namespace ModularBlazor.App.Components;

public partial class Routes
{
    public static List<Assembly> AdditionalAssemblies = new List<Assembly>()
    {
        typeof(ModularBlazor.Account.Components._Imports).Assembly
    };
}
