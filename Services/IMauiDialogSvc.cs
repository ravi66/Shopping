using System.Runtime.CompilerServices;

namespace Shopping.Services
{
    internal interface IMauiDialogSvc
    {
        Task Alert(string message);
        Task<bool> Confirm(string? title, string message, string accpet, string cancel);
    }
}
