namespace KodieLingo.Shared
{
    public partial class MainLayout
    {
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender && ClientState.User == null)
            {
                navManager.NavigateTo("/loginsignup");
            }
        }
    }
}
