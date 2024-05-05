namespace Shopping.Services
{
    internal class MauiDialogSvc : IMauiDialogSvc
    {
        public async Task Alert(string title)
        {
            await Application.Current.MainPage.DisplayAlert(title, null, "Ok");
        }

        public async Task<bool> Confirm(string? title, string? message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> EditAisle(string title, string? aisleName)
        {
            return await Application.Current.MainPage.DisplayPromptAsync(title, null, "Ok", "Cancel", "Aisle", 25, null, aisleName);
        }
    }
}