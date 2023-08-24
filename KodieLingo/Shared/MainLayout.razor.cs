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
    }
}
