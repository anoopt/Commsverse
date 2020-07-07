# Connect to Teams environment with credentials
Connect-MicrosoftTeams

# Create a new Team
$team = New-Team -DisplayName "Commsverse PowerShell" -Description "Team created from PowerShell" -Visibility Public

# Additional owners
Add-TeamUser -GroupId $team.GroupId -User "AdeleV@anoopccdev1.onmicrosoft.com" -Role Owner

# Channels
New-TeamChannel -GroupId $team.GroupId -DisplayName "Announcements 📢" -Description "This is a sample announcements channel that is favorited by default. Use this channel to make important team, product, and service announcements."
New-TeamChannel -GroupId $team.GroupId -DisplayName "Training 🏋" -Description "This is a sample training channel."

# Disconnect from Teams environment
Disconnect-MicrosoftTeams