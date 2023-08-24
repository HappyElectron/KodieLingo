namespace KodieLingo.Shared
{
    public partial class MainLayout
    {
        private void Redirect()
        {
            navManager.NavigateTo("/loginsignup");
        }
        private void RedirectToFriend(string url)
        {
            navManager.NavigateTo("/friends/" + url);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender)
            {
                navManager.NavigateTo("/loginsignup");
            }
        }
    }
}
