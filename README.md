# MASA.Blazor.Components [![Publish to Nuget](https://github.com/capdiem/MASA.Blazor.Experimental.Components/actions/workflows/nuget.yml/badge.svg)](https://github.com/capdiem/MASA.Blazor.Experimental.Components/actions/workflows/nuget.yml)
Experimental components about MASA.Blazor

## Usage
```shell
dotnet add package MASA.Blazor.Experimental.Components
```
```c#
// Program.cs for minimal apis
builder.Services.AddMasaBlazorExperimentalComponents();
```
```html
<!-- _Layout.cshtml -->
<script src="_content/MASA.Blazor.Experimental.Components/js/experimental.js"></script>
```
```html
<!-- MainLayout.razor -->
<MApp>
    <!-- your code here -->

    <!-- Support inject the IPopupService -->
    <MasaPopupProvider/>
</MApp>
```
