[CmdletBinding()]
Param (
    [string] $Site = "fabrikam",
    [string] $App = "/user",
    [string] $Section = "appSettings"
)

& C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "$Section" -site "$Site" -app "$App"