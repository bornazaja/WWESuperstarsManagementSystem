using System.Threading.Tasks;
using WWESuperstarsManagementSystemConsole.Views.Interfaces;

namespace WWESuperstarsManagementSystemConsole
{
    public class Application : IApplication
    {
        private IRootView _rootView;

        public Application(IRootView rootView)
        {
            _rootView = rootView;
        }

        public async Task RunAsync()
        {
            await _rootView.ShowAsync();
        }
    }
}
