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
    public class BrandView : IBrandView
    {
        private IBrandApi _brandApi;

        public BrandView(IBrandApi brandApi)
        {
            _brandApi = brandApi;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("Brands");
                ConsoleHelper.ShowEnumValuesAsMenu<BrandMenu>();

                BrandMenu choice = ConsoleHelper.GetEnum<BrandMenu>("Choose option: ", false);
                Console.Clear();

                switch (choice)
                {
                    case BrandMenu.ReturnToMainMenu:
                        return;
                    case BrandMenu.Add:
                        await AddAsync();
                        break;
                    case BrandMenu.Update:
                        await UpdateAsync();
                        break;
                    case BrandMenu.Delete:
                        await DeleteAsync();
                        break;
                    case BrandMenu.FindById:
                        await FindByIDAsync();
                        break;
                    case BrandMenu.ShowAll:
                        await ShowAllAsync();
                        break;
                    case BrandMenu.AdvancedSearch:
                        await AdvancedSearchAsync();
                        break;
                    case BrandMenu.ShowTotalCount:
                        await ShowTotalCountAsync();
                        break;
                }

                ConsoleHelper.ShowPressAnyKeyToContinue();

            } while (true);
        }

        private async Task AddAsync()
        {
            ConsoleHelper.ShowHeading("Add brand");

            string name = ConsoleHelper.GetString("Enter name: ");

            BrandSaveDto brandSaveDto = new BrandSaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<BrandReadDto> saveResponseDto = await _brandApi.AddAsync(brandSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task UpdateAsync()
        {
            ConsoleHelper.ShowHeading("Update brand");

            int idBrand = ConsoleHelper.GetInt("Enter id brand: ");
            string name = ConsoleHelper.GetString("Enter name: ");

            BrandSaveDto brandSaveDto = new BrandSaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<BrandReadDto> saveResponseDto = await _brandApi.UpdateAsync(idBrand, brandSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task DeleteAsync()
        {
            ConsoleHelper.ShowHeading("Delete brand");

            int idBrand = ConsoleHelper.GetInt("Enter id brand: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _brandApi.DeleteAsync(idBrand);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while deleting data.");
        }

        private async Task FindByIDAsync()
        {
            ConsoleHelper.ShowHeading("Find brand by id");

            int idBrand = ConsoleHelper.GetInt("Enter id brand: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<BrandReadDto> singleResponseDto = await _brandApi.GetByIDAsync(idBrand);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowAllAsync()
        {
            ConsoleHelper.ShowHeading("Show all brands");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                ListResponseDto<BrandReadDto> listResponseDto = await _brandApi.GetAllAsync();
                ConsoleHelper.ShowListResponse(listResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task AdvancedSearchAsync()
        {
            ConsoleHelper.ShowHeading("Advanced search of brands");

            string propertiesToSearch = "IDBrand,Name";

            QueryCriteriaRequestDto queryCriteriaRequestDto = ConsoleHelper.GetQueryCriteriaRequest(propertiesToSearch);

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                PagedResponseDto<BrandReadDto> pagedResponseDto = await _brandApi.GetAllAsync(queryCriteriaRequestDto);
                ConsoleHelper.ShowPagedResponse(pagedResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowTotalCountAsync()
        {
            ConsoleHelper.ShowHeading("Show total count of brands");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _brandApi.CountAsync();
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }
    }
}
