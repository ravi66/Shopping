using System.Runtime.CompilerServices;

namespace Shopping.Services
{
    internal interface IMauiDialogSvc
    {
        Task Alert(string title);
        Task<bool> Confirm(string? title, string? message, string accpet, string cancel);
        Task<string> EditAisle(string title, string? aisleName);
    }
}