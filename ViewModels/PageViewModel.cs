using epiv12demo.Models.Pages;

namespace epiv12demo.ViewModels
{
    public class PageViewModel<T>(T currentPage) : IPageViewModel<T> where T : BasePage
    {
        public T CurrentPage { get; } = currentPage;
    }
}
