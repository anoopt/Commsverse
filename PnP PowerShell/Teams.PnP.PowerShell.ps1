# Run the below script only once
# Initialize-PnPPowerShellAuthentication -ApplicationName "Commsverse PnP PowerShell" -Tenant anoopccdev1.onmicrosoft.com -Store CurrentUser

# Connect to the tenant using app credentials
Connect-PnPOnline -Tenant anoopccdev1.onmicrosoft.com -ClientId 547a340a-6712-4d4a-aaa8-3dfa0bc970d5 -Thumbprint 57702D483435548EA6033E58452F58C5BD9399B3 -Url https://anoopccdev1-admin.sharepoint.com

# Apply the PnP template that creates a Team
Apply-PnPTenantTemplate -Path ".\TeamsTemplate.xml"

# Disconnect from the tenant
Disconnect-PnPOnline