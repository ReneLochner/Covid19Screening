using Covid19Screening.Wpf.Common;

namespace Bakery.Wpf.Common
{
  public interface IWindowController
    {
    void ShowWindow(BaseViewModel viewModel, bool showAsDialog = false);
    void CloseWindow(BaseViewModel viewModel);
  }
}
