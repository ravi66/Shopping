namespace Shopping.Services
{
    internal class MauiDialogSvc : IMauiDialogSvc
    {
        public async Task Alert(string message)
        {
            await Application.Current.MainPage.DisplayAlert(null, message, "Ok");
        }

        public async Task<bool> Confirm(string? title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
