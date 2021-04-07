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
    public class CityView : ICityView
    {
        private ICityApi _cityApi;

        public CityView(ICityApi cityApi)
        {
            _cityApi = cityApi;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("Cities");
                ConsoleHelper.ShowEnumValuesAsMenu<CityMenu>();

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
                }

                ConsoleHelper.ShowPressAnyKeyToContinue();

            } while (true);
        }

        private async Task AddAsync()
        {
            ConsoleHelper.ShowHeading("Add city");

            string name = ConsoleHelper.GetString("Enter name: ");
            int countryId = ConsoleHelper.GetInt("Enter country id: ");

            CitySaveDto citySaveDto = new CitySaveDto
            {
                Name = name,
                CountryID = countryId
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<CityReadDto> saveResponseDto = await _cityApi.AddAsync(citySaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task UpdateAsync()
        {
            ConsoleHelper.ShowHeading("Update city: ");

            int idCity = ConsoleHelper.GetInt("Enter id city: ");
            string name = ConsoleHelper.GetString("Enter name: ");
            int countryId = ConsoleHelper.GetInt("Enter country id: ");

            CitySaveDto citySaveDto = new CitySaveDto
            {
                Name = name,
                CountryID = countryId
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<CityReadDto> saveResponseDto = await _cityApi.UpdateAsync(idCity, citySaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task DeleteAsync()
        {
            ConsoleHelper.ShowHeading("Delete city");

            int idCity = ConsoleHelper.GetInt("Enter id city: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _cityApi.DeleteAsync(idCity);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while deleting data.");
        }

        private async Task FindByIDAsync()
        {
            ConsoleHelper.ShowHeading("Find city by id");

            int idCity = ConsoleHelper.GetInt("Enter id city: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<CityReadDto> singleResponseDto = await _cityApi.GetByIDAsync(idCity);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowAllAsync()
        {
            ConsoleHelper.ShowHeading("Show all cities");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                ListResponseDto<CityReadDto> listResponseDto = await _cityApi.GetAllAsync();
                ConsoleHelper.ShowListResponse(listResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task AdvancedSearchAsync()
        {
            ConsoleHelper.ShowHeading("Advanced search of cities");

            string propertiesOfSearch = "IDCity,Name,Country.Name";

            QueryCriteriaRequestDto queryCriteriaRequestDto = ConsoleHelper.GetQueryCriteriaRequest(propertiesOfSearch);

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                PagedResponseDto<CityReadDto> pagedResponseDto = await _cityApi.GetAllAsync(queryCriteriaRequestDto);
                ConsoleHelper.ShowPagedResponse(pagedResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowTotalCountAsync()
        {
            ConsoleHelper.ShowHeading("Show total count of cities");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _cityApi.CountAsync();
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }
    }
}
