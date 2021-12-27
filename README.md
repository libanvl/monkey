[![.NET 6](https://github.com/libanvl/monkey/actions/workflows/dotnet.yml/badge.svg)](https://github.com/libanvl/monkey/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/libanvl/monkey/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/libanvl/monkey/actions/workflows/codeql-analysis.yml)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/libanvl.uuid?label=libanvl.uuid)](https://www.nuget.org/packages/libanvl.monkey.meta/)

# libanvl.monkey.meta

Meta build tool for Monkey

## Requirements

[.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

## Releases

* NuGet packages are available on [NuGet.org](https://www.nuget.org/packages/libanvl.monkey.meta)
  * Embedded debug symbols
  * Source Link enabled
* NuGet packages from CI builds are available on the [libanvl GitHub feed](https://github.com/libanvl/monkey/packages/)

## Features

- [X] Complete feature
- [ ] Future feature

## Examples

```csharp

public Guid GetWindowsTerminalNamespacedProfileGuid(string profileName)
{
    Guid terminalNamespace = new("2BDE4A90-D05F-401C-9492-E40884EAD1D8");
    return UUID.V(terminalNamespace, profileName);
}

```

# Maintenance

* Primary development happens in `main` branch.
* Use the [Nerdbank GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning/) CLI [`prepare-release`](https://github.com/dotnet/Nerdbank.GitVersioning/blob/master/doc/nbgv-cli.md#preparing-a-release) command to create a release/stabilization branch.
  * `nbgv prepare-release beta`
  * push the new release branch
  * push main
  * find the draft release in github, update tags, branch, release notes, etc...
  * publish the draft to release to NuGet.org