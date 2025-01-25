# ModularBlazor

Goal : Move Blazor components like `Account` pages to a separate project in order to have a clear separation of features in different modules.

## Step 0

- Create a new Blazor app `ModularBlazor.App` with Authentication.
- Execute `dotnet ef update database` to create the database.
- Create a new user using the `Register` page and login to test authenticated pages.

## Step 1

- Create project `ModularBlazor.Account` in Modules folder.
- Add reference of `ModularBlazor.Account` to `ModularBlazor.App` application.
- Change Project Sdk to `<Project Sdk="Microsoft.NET.Sdk.Razor">`
- Add AspNetCore assemblies references to `ModularBlazor.Account.csproj`:

```
		<FrameworkReference Include="Microsoft.AspNetCore.App" />
		<PackageReference Include="Microsoft.AspNetCore.Components" Version="9.0.1" />
		<PackageReference Include="Microsoft.AspNetCore.Components.Web" Version="9.0.1" />
```

## Step 2

- Move `Component\Account` Pages to `ModularBlazor.Account` project.
- Rename namespaces to `ModularBlazor.Account.Components.Account`.
- Add `_Imports.razor` file to `ModularBlazor.Account.Components` folder
- Change scope of `internal sealed` classes to `public` to use them in the main application.

## Step 3
- Add `Routes.razor.cs` below `Routes.razor`, declare static `AdditionalAssemblies` and add the `ModularBlazor.Account` Assembly:

```
public partial class Routes
{
    public static List<Assembly> AdditionalAssemblies = new List<Assembly>()
    {
        typeof(ModularBlazor.Account.Components._Imports).Assembly
    };
}
```

- In `Program.cs`, call `AdditionalAssemblies`:

```
App.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(Routes.AdditionalAssemblies.ToArray());
```

## Step 3

- Move `Components\Layout` folder to `ModularBlazor.Account` project (`ManageLayout` needs the main Layout).
- Move `Data` folder to `ModularBlazor.Account` project (`ApplicationDbContext`, `ApplicationUser`, ...).

## Step 4

- Create project `ModularBlazor.Data`
- Add Entity Framework Core packages to `ModularBlazor.Data.csproj`.
- Move `Data` folder to `ModularBlazor.Data`.
- Add reference of `ModularBlazor.Data` to `ModularBlazor.Account` project.
- Change namespace `ModularBlazor.App.Data` to `ModularBlazor.Data`.
