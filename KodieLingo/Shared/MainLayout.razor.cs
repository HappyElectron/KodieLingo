using KodieLingo.Data;
using KodieLingo.Model;
using Microsoft.EntityFrameworkCore;

namespace KodieLingo.Shared
{
    public partial class MainLayout
    {
        private DatabaseContext? db { get; set; }

        //private ICollection<User> IncomingRequests { get; set; }

        public bool AddFriendsActive { get; set; } = false;
        public bool IncomingRequestsActive { get; set; } = false;

        private void RedirectToFriend(string url)
        {
            navManager.NavigateTo("/friends/" + url);
        }

        protected async override Task OnInitializedAsync()
        {
            db ??= ContextFactory.CreateDbContext();

            // Trying to eliminate some db queries: Shits itself.
            // IncomingRequests = db.Users.Include(b => b.FriendReqIncoming).First(x => x.Username == ClientState.User.Username).FriendReqIncoming;
		}

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender && ClientState.User == null)
            {
                navManager.NavigateTo("/loginsignup");
            }
        }

        private void IncomingFriendRequests()
        {
            IncomingRequestsActive = !IncomingRequestsActive;
            AddFriendsActive = false;
        }

        private void AddAFriend()
        {
            AddFriendsActive = !AddFriendsActive;
            IncomingRequestsActive = false;
        }

        private void AllFriends()
        {
            IncomingRequestsActive = false;
            AddFriendsActive = false;
        }
    }
}
