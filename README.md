# Uno Platform port of Xaml Behaviors

This port allows for Uno-based apps to use behaviors on iOS, Android, WebAssembly and Desktop (Skia).

The [Uno.Microsoft.Xaml.Behaviors.Interactivity.WinUI](https://www.nuget.org/packages/Uno.Microsoft.Xaml.Behaviors.Interactivity.WinUI) NuGet package is available.

| Package version | Uno Platform | Target frameworks |
| --------------- | ------------ | ----------------- |
| 4.x | 7.0 and later | `net10.0`, `net10.0-ios`, `net10.0-android` |
| 3.x | 5.x / 6.x | `net8.0`, `net8.0-ios`, `net8.0-android`, `net8.0-macos`, `net8.0-maccatalyst` |

The UWP-flavoured `Uno.Microsoft.Xaml.Behaviors.Interactivity` package (based on `Uno.UI`) is discontinued; its last version is 3.x.

On the WinAppSDK (`-windows`) target, reference Microsoft's package instead:

```xml
<ItemGroup Condition="$(TargetFramework.Contains('-windows'))">
  <PackageReference Include="Microsoft.Xaml.Behaviors.WinUI.Managed" Version="3.0.1" />
</ItemGroup>
<ItemGroup Condition="!$(TargetFramework.Contains('-windows'))">
  <PackageReference Include="Uno.Microsoft.Xaml.Behaviors.Interactivity.WinUI" Version="4.0.0" />
</ItemGroup>
```

## Building and testing the Uno package

The repository uses `Uno.Sdk.Private` (pinned in the root `global.json`) and the .NET 10 SDK.

- Build and pack: `dotnet build src/BehaviorsSDKManaged/Microsoft.Xaml.Interactivity/Microsoft.Xaml.Interactivity.Uno.csproj -c Release`
- Runtime tests (Skia desktop): build `src/BehaviorsSDKManaged/Microsoft.Xaml.Interactivity.RuntimeTests`, then run its `net10.0-desktop` output with `UNO_RUNTIME_TESTS_RUN_TESTS={}` and `UNO_RUNTIME_TESTS_OUTPUT_PATH=<results.xml>` set, or launch it normally to use the interactive test runner.

# **XAML Behaviors**
XAML Behaviors is an easy-to-use means of adding common and reusable interactivity to your Windows UWP applications with minimal code. It is available for both native and managed applications. Use of XAML Behaviors is governed by the MIT License

XAML Behaviors is an easy-to-use means of adding common and reusable interactivity to your Windows UWP applications with minimal code. It is available for managed applications only. Use of XAML Behaviors is governed by the MIT License

## Build Status

| Platform | Status |
| -------- | ------ |
| Managed | ![Build Managed](https://github.com/microsoft/XamlBehaviors/workflows/Build%20Managed/badge.svg) |

## Getting Started

### Where to get it

- NuGet package for [Managed](https://www.nuget.org/packages/Microsoft.Xaml.Behaviors.Uwp.Managed/)
- [Source Code](https://github.com/Microsoft/XamlBehaviors)

### Resources

- [Documentation](https://github.com/Microsoft/XamlBehaviors/wiki)
- [Samples](/samples)
- [Changelog](https://github.com/Microsoft/XamlBehaviors/wiki/Changelog)
- [![Join the chat at https://gitter.im/Microsoft/XamlBehaviors](https://badges.gitter.im/Microsoft/XamlBehaviors.svg)](https://gitter.im/Microsoft/XamlBehaviors?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

### More Info

- [Report a bug or ask a question](https://github.com/Microsoft/XamlBehaviors/issues)
- [Contribute](https://github.com/Microsoft/XamlBehaviors/wiki/Contribute-to-XAML-Behaviors)
- [License](http://opensource.org/licenses/MIT)

### Code Example

For an example of using Behaviors in an application, here is a snippet of XAML:

```xml
<Button xmlns:Interactivity="using:Microsoft.Xaml.Interactivity">
    <Interactivity:Interaction.Behaviors>
        <Interactivity:EventTriggerBehavior EventName="Click">
            <Interactivity:ChangePropertyAction PropertyName="Background">
                <Interactivity:ChangePropertyAction.Value>
                    <SolidColorBrush Color="Red"/>
                </Interactivity:ChangePropertyAction.Value>
            </Interactivity:ChangePropertyAction>
        </Interactivity:EventTriggerBehavior>
    </Interactivity:Interaction.Behaviors>
</Button>
```

### Using Behaviors SDK

The [documentation](https://github.com/Microsoft/XamlBehaviors/wiki) explains how to install Visual Studio, add the XAML Behaviors NuGet package to your project, and get started using the API.

### Building Behaviors from Source

#### What You Need

- [Visual Studio 2022 17.12+ w/ Universal Windows Tools](https://visualstudio.microsoft.com/vs/features/universal-windows-platform/)
- [Multilingual App Toolkit](https://developer.microsoft.com/en-us/windows/develop/multilingual-app-toolkit)

#### Clone the Repository

- Go to 'View' -> 'Team Explorer' -> 'Local Git Repositories' -> 'Clone'
- Add the XAML Behaviors repository URL (https://github.com/Microsoft/XamlBehaviors) and hit 'Clone'

#### Build and Create Managed XAML Behaviors NuGet

- Ensure that [nuget.exe](https://learn.microsoft.com/en-us/nuget/install-nuget-client-tools?tabs=windows) is available in PATH
- If you're using Visual Studio
  - Open the "BehaviorsSDKManaged.sln" solution in Visual Studio
  - Change Build Configuration to Release
  - Build solution with right click > Build, or by clicking F6
- If you're building from CLI (Visual Studio Developer Command prompt):
  - Run `nuget restore src\BehaviorsSDKManaged\BehaviorsSDKManaged.sln`
  - Run `msbuild -t:build src\BehaviorsSDKManaged\BehaviorsSDKManaged.sln /p:Configuration=Release`

For UWP:
- Run `msbuild /t:pack src\BehaviorsSDKManaged\Microsoft.Xaml.Interactivity.Uwp\Microsoft.Xaml.Interactivity.Uwp.csproj  /p:Configuration=Release`
  - *(Optional)* Add `/p:TimestampPackage=true` to include the timestamp in the NuGet package version

For WinUI:

- Run `msbuild /t:Pack src\BehaviorsSDKManaged\Microsoft.Xaml.Interactivity.WinUI\Microsoft.Xaml.Interactivity.WinUI.csproj /p:Configuration=Release`
  - *(Optional)* Add `/p:TimestampPackage=true` to include the timestamp in the NuGet package version
