# Uno Platform port of Xaml Behaviors

This port allows for Uno-based apps to use behaviors on Windows, iOS, Android and WebAssembly.

The WinUI [Uno.Microsoft.Xaml.Behaviors.WinUI.Managed](https://www.nuget.org/packages/Uno.Microsoft.Xaml.Behaviors.Uwp.Managed) and UWP [Uno.Microsoft.Xaml.Behaviors.Uwp.Managed](https://www.nuget.org/packages/Uno.Microsoft.Xaml.Behaviors.Uwp.Managed) Nuget packages is available.

To install the WinUI behaviors in .NET class libraries, such as the ones found in Uno Platform 4.7, use the following:

```xml
<ItemGroup Condition="'$(TargetFramework)' == 'net6.0-windows10.0.19041.0'">
  <PackageReference Include="Microsoft.Xaml.Behaviors.WinUI.Managed" Version="2.0.9" />
</ItemGroup>
<ItemGroup Condition="'$(TargetFramework)' != 'net6.0-windows10.0.19041.0'">
  <PackageReference Include="Uno.Microsoft.Xaml.Behaviors.WinUI.Managed" Version="2.3.0" />
</ItemGroup>
```
You may need to adjust `net6.0-windows10.0.19041.0` to the TargetFramework value found in your project.

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
