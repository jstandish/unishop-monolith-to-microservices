# This script installs IIS and the features required to
# run West Wind Web Connection.
#
# * Make sure you run this script from a Powershel Admin Prompt!
# * Make sure Powershell Execution Policy is bypassed to run these scripts:
# * YOU MAY HAVE TO RUN THIS COMMAND PRIOR TO RUNNING THIS SCRIPT!
Set-ExecutionPolicy Bypass -Scope Process

# To list all Windows Features: dism /online /Get-Features
# Get-WindowsOptionalFeature -Online 
# LIST All IIS FEATURES: 
# Get-WindowsOptionalFeature -Online | where FeatureName -like 'IIS-*'
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex;

#Install Git
choco install -y git

Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-WebServerRole
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-WebServer
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-CommonHttpFeatures
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HttpErrors
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HttpRedirect
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ApplicationDevelopment
Enable-WindowsOptionalFeature -online -NoRestart -FeatureName NetFx4Extended-ASPNET45
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-NetFxExtensibility45
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HealthAndDiagnostics
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HttpLogging
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-LoggingLibraries
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-RequestMonitor
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HttpTracing
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-Security
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-RequestFiltering
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-Performance
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-WebServerManagementTools
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-IIS6ManagementCompatibility
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-Metabase
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ManagementConsole
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-BasicAuthentication
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-WindowsAuthentication
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-StaticContent
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-DefaultDocument
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-WebSockets
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ApplicationInit
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ISAPIExtensions
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ISAPIFilter
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-HttpCompressionStatic
Enable-WindowsOptionalFeature -Online -NoRestart -FeatureName IIS-ASPNET45

Import-Module WebAdministration

# Create app pool
New-WebAppPool -name "NewWebSiteAppPool"  -force

$appPool = Get-Item IIS:\AppPools\NewWebSiteAppPool
$appPool.processModel.identityType = "NetworkService"
$appPool.enable32BitAppOnWin64 = 1
$appPool | Set-Item

Stop-WebSite -Name "Default Web Site"
# Create Website
md "c:\Web Sites\NewWebSite"

# All on one line
$site = $site = new-WebSite -name "NewWebSite" -PhysicalPath "c:\Web Sites\NewWebSite"  -HostHeader "*" -ApplicationPool "NewWebSiteAppPool" -force

md C:\source
."C:\Program Files\Git\bin\git.exe" clone https://github.com/jstandish/unishop-monolith-to-microservices.git C:\source