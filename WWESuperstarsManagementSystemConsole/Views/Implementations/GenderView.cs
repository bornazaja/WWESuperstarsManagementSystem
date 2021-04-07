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
    public class GenderView : IGenderView
    {
        private IGenderApi _genderApi;

        public GenderView(IGenderApi genderApi)
        {
            _genderApi = genderApi;
        }

        public async Task ShowAsync()
        {
            do
            {
                ConsoleHelper.ShowHeading("Genders");
                ConsoleHelper.ShowEnumValuesAsMenu<GenderMenu>();

                GenderMenu choice = ConsoleHelper.GetEnum<GenderMenu>("Choose option: ", false);
                Console.Clear();

                switch (choice)
                {
                    case GenderMenu.ReturnToMainMenu:
                        return;
                    case GenderMenu.Add:
                        await AddAsync();
                        break;
                    case GenderMenu.Update:
                        await UpdateAsync();
                        break;
                    case GenderMenu.Delete:
                        await DeleteAsync();
                        break;
                    case GenderMenu.FindById:
                        await FindByIDAsync();
                        break;
                    case GenderMenu.ShowAll:
                        await ShowAllAsync();
                        break;
                    case GenderMenu.AdvancedSearch:
                        await AdvancedSearchAsync();
                        break;
                    case GenderMenu.ShowTotalCount:
                        await ShowTotalCountAsync();
                        break;
                }

                ConsoleHelper.ShowPressAnyKeyToContinue();

            } while (true);
        }

        private async Task AddAsync()
        {
            ConsoleHelper.ShowHeading("Add gender");

            string name = ConsoleHelper.GetString("Enter name: ");

            GenderSaveDto genderSaveDto = new GenderSaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<GenderReadDto> saveResponseDto = await _genderApi.AddAsync(genderSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task UpdateAsync()
        {
            ConsoleHelper.ShowHeading("Update gender");

            int idGender = ConsoleHelper.GetInt("Enter id gender: ");
            string name = ConsoleHelper.GetString("Enter name: ");

            GenderSaveDto genderSaveDto = new GenderSaveDto
            {
                Name = name
            };

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SaveResponseDto<GenderReadDto> saveResponseDto = await _genderApi.UpdateAsync(idGender, genderSaveDto);
                ConsoleHelper.ShowSaveResponseDto(saveResponseDto);
            }, "An error occurred while saving data.");
        }

        private async Task DeleteAsync()
        {
            ConsoleHelper.ShowHeading("Delete gender");

            int idGender = ConsoleHelper.GetInt("Enter id gender: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _genderApi.DeleteAsync(idGender);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while deleting data.");
        }

        private async Task FindByIDAsync()
        {
            ConsoleHelper.ShowHeading("Find gender by id");

            int idGender = ConsoleHelper.GetInt("Enter id gender: ");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<GenderReadDto> singleResponseDto = await _genderApi.GetByIDAsync(idGender);
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowAllAsync()
        {
            ConsoleHelper.ShowHeading("Show all genders");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                ListResponseDto<GenderReadDto> listResponseDto = await _genderApi.GetAllAsync();
                ConsoleHelper.ShowListResponse(listResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task AdvancedSearchAsync()
        {
            ConsoleHelper.ShowHeading("Advanced search of genders");

            string propertiesToSearch = "IDGender,Name";

            QueryCriteriaRequestDto queryCriteriaRequestDto = ConsoleHelper.GetQueryCriteriaRequest(propertiesToSearch);

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                PagedResponseDto<GenderReadDto> pagedResponseDto = await _genderApi.GetAllAsync(queryCriteriaRequestDto);
                ConsoleHelper.ShowPagedResponse(pagedResponseDto);
            }, "An error occurred while retriving data.");
        }

        private async Task ShowTotalCountAsync()
        {
            ConsoleHelper.ShowHeading("Show total count of genders");

            await ConsoleHelper.RunWithTryCatchAsync(async () =>
            {
                SingleResponseDto<int> singleResponseDto = await _genderApi.CountAsync();
                ConsoleHelper.ShowSingleResponse(singleResponseDto);
            }, "An error occurred while retriving data.");
        }
    }
}
