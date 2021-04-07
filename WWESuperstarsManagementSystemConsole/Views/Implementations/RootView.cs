using System;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemConsole.Enums;
using WWESuperstarsManagementSystemConsole.Helpers;
using WWESuperstarsManagementSystemConsole.Views.Interfaces;

namespace WWESuperstarsManagementSystemConsole.Views.Implementations
{
    public class RootView : IRootView
    {
        private IBrandView _brandView;
        private ICityView _cityView;
        private ICountryView _countryView;
        private IGenderView _genderView;
        private ISuperstarView _superstarView;

        public RootView(IBrandView brandView, ICityView cityView, ICountryView countryView, IGenderView genderView, ISuperstarView superstarView)
        {
            _brandView = brandView;
            _cityView = cityView;
            _countryView = countryView;
            _genderView = genderView;
            _superstarView = superstarView;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("WWE Superstars Management System");
                ConsoleHelper.ShowEnumValuesAsMenu<MainMenu>();

                MainMenu choice = ConsoleHelper.GetEnum<MainMenu>("Choose option: ", false);
                Console.Clear();

                switch (choice)
                {
                    case MainMenu.Exit:
                        Environment.Exit(0);
                        break;
                    case MainMenu.Superstars:
                        await _superstarView.ShowAsync();
                        break;
                    case MainMenu.Brands:
                        await _brandView.ShowAsync();
                        break;
                    case MainMenu.Cities:
                        await _cityView.ShowAsync();
                        break;
                    case MainMenu.Countries:
                        await _countryView.ShowAsync();
                        break;
                    case MainMenu.Genders:
                        await _genderView.ShowAsync();
                        break;
                }

            } while (true);
        }
    }
}
