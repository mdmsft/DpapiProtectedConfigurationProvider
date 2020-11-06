[CmdletBinding()]
Param (
    [string] $Site = "fabrikam",
    [string] $App = "/user",
    [string] $Provider = "user",
    [string] $Section = "appSettings"
)

& C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pe "$Section" -site "$Site" -app "$App" -prov "$Provider"