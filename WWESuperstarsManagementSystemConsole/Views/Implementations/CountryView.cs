using System;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemConsole.Enums;
using WWESuperstarsManagementSystemConsole.Helpers;
using WWESuperstarsManagementSystemConsole.Views.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.API.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;

namespace WWESuperstarsManagementSystemConsole.Views.Implementations
{
    public class CountryView : ICountryView
    {
        private ICountryApi _countryApi;

        public CountryView(ICountryApi countryApi)
        {
            _countryApi = countryApi;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("Countries");
                ConsoleHelper.ShowEnumValuesAsMenu<CountryMenu>();

                CityMenu choice = ConsoleHelper.GetEnum<CityMenu>("Choose option: ", false);
                Console.Clear();

                switch (choice)
                {
                    case CityMenu.ReturnToMainMenu:
                        return;
                    case CityMenu.Add:
                        await AddAsync();
                        break;
                    case CityMenu.Update:
                        await UpdateAsync();
                        break;
                    case CityMenu.Delete:
                        await DeleteAsync();
                        break;
                    case CityMenu.FindById:
                        await FindByIDAsync();
                        break;
                    case CityMenu.ShowAll:
                        await ShowAllAsync();
                        break;
                    case CityMenu.AdvancedSearch:
                        await AdvancedSearchAsync();
                        break;
                    case CityMenu.ShowTotalCount:
                        await ShowTotalCountAsync();
                        break;
                    default:
                        break;
                }

                ConsoleHelper.ShowPressAnyKeyToContinue();

            } while (true);
        }

        private async Task AddAsync()
        {
            ConsoleHelper.ShowHeading("Add country");

            string name = ConsoleHelper.GetString("Enter name: ");

            CountrySaveDto countrySaveDto = new CountrySaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<CountryReadDto> saveResponseDto = await _countryApi.AddAsync(countrySaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task UpdateAsync()
        {
            ConsoleHelper.ShowHeading("Update country");

            int idCountry = ConsoleHelper.GetInt("Enter id country: ");
            string name = ConsoleHelper.GetString("Enter name: ");

            CountrySaveDto countrySaveDto = new CountrySaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<CountryReadDto> saveResponseDto = await _countryApi.UpdateAsync(idCountry, countrySaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task DeleteAsync()
        {
            ConsoleHelper.ShowHeading("Delete country");

            int idCountry = ConsoleHelper.GetInt("Enter id country: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _countryApi.DeleteAsync(idCountry);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while deleting data.");
        }

        private async Task FindByIDAsync()
        {
            ConsoleHelper.ShowHeading("Find country by id");

            int idCountry = ConsoleHelper.GetInt("Enter id country: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<CountryReadDto> singleResponseDto = await _countryApi.GetByIDAsync(idCountry);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowAllAsync()
        {
            ConsoleHelper.ShowHeading("Show all countries");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                ListResponseDto<CountryReadDto> listResponseDto = await _countryApi.GetAllAsync();
                ConsoleHelper.ShowListResponse(listResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task AdvancedSearchAsync()
        {
            ConsoleHelper.ShowHeading("Advanced search of countries");

            string propertiesToSearch = "IDCountry,Name";

            QueryCriteriaRequestDto queryCriteriaRequestDto = ConsoleHelper.GetQueryCriteriaRequest(propertiesToSearch);

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                PagedResponseDto<CountryReadDto> pagedResponseDto = await _countryApi.GetAllAsync(queryCriteriaRequestDto);
                ConsoleHelper.ShowPagedResponse(pagedResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowTotalCountAsync()
        {
            ConsoleHelper.ShowHeading("Show total count of countries");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _countryApi.CountAsync();
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }
    }
}
