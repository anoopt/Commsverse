using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commsverse.ProvisionTeams
{
    class AppSettings
    {
        // configuration data for confidential client app
        public const string clientId = "";
        public const string clientSecret = "";

        // generic v2 endpoint references "organizations" instead of "common"
        public const string tenantName = "yourtenant.onmicrosoft.com";
        public const string tenantCommonAuthority = "https://login.microsoftonline.com/organizations";
        public const string tenantSpecificAuthority = "https://login.microsoftonline.com/" + tenantName;
    }
    class Program
    {
        static IAuthenticationProvider authProvider = new AppOnlyAuthProvider();
        static GraphServiceClient graphServiceClient = new GraphServiceClient(authProvider);

        static async Task Main(string[] args)
        {
            Console.WriteLine("Creating team...");
            await CreateTeam();
            Console.WriteLine("Team created.");
            Console.ReadLine();
        }

        static async Task CreateTeam()
        {
            var owner = await graphServiceClient
                                .Users["anoop@anoopccdev1.onmicrosoft.com"]
                                .Request()
                                .GetAsync();

            TeamOwnersCollectionWithReferencesPage owners = new TeamOwnersCollectionWithReferencesPage();
            owners.Add(owner);


            TeamChannelsCollectionPage channels = new TeamChannelsCollectionPage
            {
                new Channel()
                {
                    DisplayName = "Announcements 📢",
                    IsFavoriteByDefault = true,
                    Description = "This is a sample announcements channel that is favorited by default. Use this channel to make important team, product, and service announcements."
                },
                new Channel
                {
                    DisplayName = "Training 🏋",
                    IsFavoriteByDefault = false,
                    Description = "This is a sample training channel.",
                }
            };

            var team = new Team
            {
                Visibility = TeamVisibilityType.Private,
                DisplayName = "Commsverse Console App",
                Description = "This is a sample team",
                Owners = owners,
                Channels = channels,
                MemberSettings = new TeamMemberSettings
                {
                    AllowCreateUpdateChannels = true,
                    AllowDeleteChannels = true,
                    AllowAddRemoveApps = true,
                    AllowCreateUpdateRemoveTabs = true,
                    AllowCreateUpdateRemoveConnectors = true
                },
                GuestSettings = new TeamGuestSettings
                {
                    AllowCreateUpdateChannels = false,
                    AllowDeleteChannels = false
                },
                FunSettings = new TeamFunSettings
                {
                    AllowGiphy = true,
                    GiphyContentRating = GiphyRatingType.Moderate,
                    AllowStickersAndMemes = true,
                    AllowCustomMemes = true
                },
                MessagingSettings = new TeamMessagingSettings
                {
                    AllowUserEditMessages = true,
                    AllowUserDeleteMessages = true,
                    AllowOwnerDeleteMessages = true,
                    AllowTeamMentions = true,
                    AllowChannelMentions = true
                },
                DiscoverySettings = new TeamDiscoverySettings
                {
                    ShowInTeamsSearchAndSuggestions = true
                },
                AdditionalData = new Dictionary<string, object>()
                {
                    {"template@odata.bind", "https://graph.microsoft.com/beta/teamsTemplates('standard')"}
                }
            };
            await graphServiceClient
                    .Teams
                    .Request()
                    .AddAsync(team);
        }
    }
}
