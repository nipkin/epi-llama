using epiv12demo.Models.Pages;

namespace epiv12demo.ViewModels
{
    public interface IPageViewModel<out T> where T : BasePage
    {
        T CurrentPage { get; }
    }
}
