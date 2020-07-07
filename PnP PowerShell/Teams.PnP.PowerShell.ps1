# Run the below script only once
# Initialize-PnPPowerShellAuthentication -ApplicationName "Commsverse PnP PowerShell" -Tenant yourtenant.onmicrosoft.com -Store CurrentUser

# Connect to the tenant using app credentials
Connect-PnPOnline -Tenant yourtenant.onmicrosoft.com -ClientId aaaaaa-bbbb-cccc-dddd-dhjksahdjkah -Thumbprint AFCDAE6E4039C0D7C88B673CA6792B392B5D121C -Url https://yourtenant-admin.sharepoint.com

# Apply the PnP template that creates a Team
Apply-PnPTenantTemplate -Path ".\TeamsTemplate.xml"

# Disconnect from the tenant
Disconnect-PnPOnline