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
    public class SuperstarView : ISuperstarView
    {
        private ISuperstarApi _superstarApi;

        public SuperstarView(ISuperstarApi superstarApi)
        {
            _superstarApi = superstarApi;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("Superstars");
                ConsoleHelper.ShowEnumValuesAsMenu<SuperstarMenu>();

                SuperstarMenu choice = ConsoleHelper.GetEnum<SuperstarMenu>("Choose option: ", false);
                Console.Clear();

                switch (choice)
                {
                    case SuperstarMenu.ReturnToMainMenu:
                        return;
                    case SuperstarMenu.Add:
                        await AddAsync();
                        break;
                    case SuperstarMenu.Update:
                        await UpdateAsync();
                        break;
                    case SuperstarMenu.Delete:
                        await DeleteAsync();
                        break;
                    case SuperstarMenu.FindById:
                        await FindByIDAsync();
                        break;
                    case SuperstarMenu.ShowAll:
                        await ShowAllAsync();
                        break;
                    case SuperstarMenu.AdvancedSearch:
                        await AdvancedSearchAsync();
                        break;
                    case SuperstarMenu.ShowTotalCount:
                        await ShowTotalCountAsync();
                        break;
                }

                ConsoleHelper.ShowPressAnyKeyToContinue();

            } while (true);
        }

        private async Task AddAsync()
        {
            ConsoleHelper.ShowHeading("Add superstar");

            string name = ConsoleHelper.GetString("Enter name: ");
            decimal heightCm = ConsoleHelper.GetDecimal("Enter height (cm): ");
            decimal weightKg = ConsoleHelper.GetDecimal("Enter weight (kg): ");
            int genderId = ConsoleHelper.GetInt("Enter gender id: ");
            int brandId = ConsoleHelper.GetInt("Enter brand id: ");
            int cityId = ConsoleHelper.GetInt("Enter city id: ");

            SuperstarSaveDto superstarSaveDto = new SuperstarSaveDto
            {
                Name = name,
                HeightCm = heightCm,
                WeightKg = weightKg,
                GenderID = genderId,
                BrandID = brandId,
                CityID = cityId
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<SuperstarReadDto> saveResponseDto = await _superstarApi.AddAsync(superstarSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task UpdateAsync()
        {
            ConsoleHelper.ShowHeading("Update superstar");

            int idSuperstar = ConsoleHelper.GetInt("Enter id superstar: ");
            string name = ConsoleHelper.GetString("Enter name: ");
            decimal heightCm = ConsoleHelper.GetDecimal("Enter height (cm): ");
            decimal weightKg = ConsoleHelper.GetDecimal("Enter weight (kg): ");
            int genderId = ConsoleHelper.GetInt("Enter gender id: ");
            int brandId = ConsoleHelper.GetInt("Enter brand id: ");
            int cityId = ConsoleHelper.GetInt("Enter city id: ");

            SuperstarSaveDto superstarSaveDto = new SuperstarSaveDto
            {
                Name = name,
                HeightCm = heightCm,
                WeightKg = weightKg,
                GenderID = genderId,
                BrandID = brandId,
                CityID = cityId
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<SuperstarReadDto> saveResponseDto = await _superstarApi.UpdateAsync(idSuperstar, superstarSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task DeleteAsync()
        {
            ConsoleHelper.ShowHeading("Delete superstar");

            int idSuperstar = ConsoleHelper.GetInt("Enter id superstar: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _superstarApi.DeleteAsync(idSuperstar);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An Error occurred while deleting data.");
        }

        private async Task FindByIDAsync()
        {
            ConsoleHelper.ShowHeading("Find superstar by id");

            int idSuperstar = ConsoleHelper.GetInt("Enter id superstar: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<SuperstarReadDto> singleResponseDto = await _superstarApi.GetByIDAsync(idSuperstar);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An Error occurred while retriving data.");
        }

        private async Task ShowAllAsync()
        {
            ConsoleHelper.ShowHeading("Show all superstars");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                ListResponseDto<SuperstarReadDto> listResponseDto = await _superstarApi.GetAllAsync();
                ConsoleHelper.ShowListResponse(listResponseDto);
            }, "An Error occurred while retriving data.");
        }

        private async Task AdvancedSearchAsync()
        {
            ConsoleHelper.ShowHeading("Advanced search of superstars");

            string propertiesToSearch = "IDSuperstar,Name,HeightCm,WeightKg,Gender.Name,Brand.Name,City.Name,City.Country.Name";

            QueryCriteriaRequestDto queryCriteriaRequestDto = ConsoleHelper.GetQueryCriteriaRequest(propertiesToSearch);

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                PagedResponseDto<SuperstarReadDto> pagedResponseDto = await _superstarApi.GetAllAsync(queryCriteriaRequestDto);
                ConsoleHelper.ShowPagedResponse(pagedResponseDto);
            }, "An Error occurred while retriving data.");
        }

        private async Task ShowTotalCountAsync()
        {
            ConsoleHelper.ShowHeading("Show total count of superstars");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _superstarApi.CountAsync();
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An Error occurred while retriving data.");
        }
    }
}
