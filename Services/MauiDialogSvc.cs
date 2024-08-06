namespace Shopping.Services
{
    internal class MauiDialogSvc : IMauiDialogSvc
    {
        public async Task Alert(string title)
        {
            if (Application.Current != null && Application.Current.MainPage != null) await Application.Current.MainPage.DisplayAlert(title, null, "Ok");
        }

        public async Task<bool> Confirm(string? title, string? message, string accept, string cancel)
        {
            if (Application.Current != null && Application.Current.MainPage != null) return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            return false;
        }

        public async Task<string> EditAisle(string title, string? aisleName)
        {
            if (Application.Current != null && Application.Current.MainPage != null) return await Application.Current.MainPage.DisplayPromptAsync(title, null, "Ok", "Cancel", "Aisle", 25, null, aisleName);
            return aisleName ?? string.Empty;
        }
    }
}