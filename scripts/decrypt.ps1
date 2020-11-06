[CmdletBinding()]
Param (
    [string] $Path = "C:\inetpub\sites\Fabrikam",
    [string] $Section = "appSettings"
)

& C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pdf "$Section" "$Path"