using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.Common.Extensions;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemConsole.Helpers
{
    public static class ConsoleHelper
    {
        private const char DividingBarChar = '*';

        public static void ConsoleWriteLine(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void ConsoleWrite(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void ShowGreenMessage(string message)
        {
            ConsoleWriteLine(message, ConsoleColor.Green);
        }

        public static void ShowYellowMessage(string message)
        {
            ConsoleWriteLine(message, ConsoleColor.Yellow);
        }

        public static void ShowRedMessage(string message)
        {
            ConsoleWriteLine(message, ConsoleColor.Red);
        }

        public static string GetString(string message)
        {
            string s;

            do
            {
                Console.Write(message);
                s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    ShowRedMessage("Invalid input. Enter again.");
                }
                else
                {
                    break;
                }

            } while (true);

            return s;
        }

        public static int GetInt(string message)
        {
            int i;

            do
            {
                Console.Write(message);

                if (!int.TryParse(Console.ReadLine(), out i))
                {
                    ShowRedMessage("Invalid input. Enter again.");
                }
                else
                {
                    break;
                }

            } while (true);

            return i;
        }

        public static decimal GetDecimal(string message)
        {
            decimal d;

            do
            {
                Console.Write(message);

                if (!decimal.TryParse(Console.ReadLine(), out d))
                {
                    ShowRedMessage("Invalid input. Enter again.");
                }
                else
                {
                    break;
                }

            } while (true);

            return d;
        }

        public static TEnum GetEnum<TEnum>(string message, bool showValues = true) where TEnum : struct, IConvertible
        {
            TEnum myEnum;
            object[] enumValues = Enum.GetValues(typeof(TEnum)).OfType<object>().ToArray().Select(x => $"{(int)x} = {x}").ToArray();

            do
            {
                int i = showValues ? GetInt($"{string.Join(", ", enumValues)}. {message}") : GetInt(message);

                if (Enum.IsDefined(typeof(TEnum), i))
                {
                    myEnum = (TEnum)Enum.ToObject(typeof(TEnum), i);
                    break;
                }
                else
                {
                    ShowRedMessage("Invalid input. Enter again.");
                }

            } while (true);

            return myEnum;
        }

        public static QueryCriteriaRequestDto GetQueryCriteriaRequest(string propertiesToSearch)
        {
            Console.WriteLine("Search criteria");
            Console.WriteLine("----------------");

            string term = GetString("Enter term: ");

            Console.WriteLine();
            Console.WriteLine("Sort criteria");
            Console.WriteLine("--------------");

            string propertyNameToSort = GetString("Enter property name: ");
            SortDirection sortDirection = GetEnum<SortDirection>("Choose sort direction: ");

            Console.WriteLine();
            Console.WriteLine("Page criteria");
            Console.WriteLine("---------------");

            int pageIndex = GetInt("Enter page index: ");
            int pageSize = GetInt("Enter page size: ");

            return new QueryCriteriaRequestDto
            {
                PropertiesToSearch = propertiesToSearch,
                SearchTerm = term,
                PropertyNameToSort = propertyNameToSort,
                SortDirection = sortDirection,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public static void ShowSaveResponseDto<TSaveDto>(SaveResponseDto<TSaveDto> saveResponseDto)
        {
            Console.WriteLine();
            ShowHeading("Response");

            if (saveResponseDto.IsSuccessful)
            {
                ShowSingleData(saveResponseDto.Data, saveResponseDto.PropertyInfoListOfDto);
                ShowGreenMessage(saveResponseDto.Message);
            }
            else
            {
                ShowRedMessage(saveResponseDto.Message);
            }

            if (!saveResponseDto.ValidationResults.IsEmpty())
            {
                Console.WriteLine();
                ShowRedMessage("Validation result");
                ShowRedMessage("------------------");

                foreach (var validationResult in saveResponseDto.ValidationResults)
                {
                    foreach (var errorMessage in validationResult.ErrorMessages)
                    {
                        ShowRedMessage($"{validationResult.PropertyName}: {errorMessage}");
                    }
                }
            }
        }

        public static void ShowSingleResponse<TReadDto>(SingleResponseDto<TReadDto> singleResponseDto)
        {
            Console.WriteLine();
            ShowHeading("Response");

            if (singleResponseDto.IsSuccessful)
            {
                ShowSingleData(singleResponseDto.Data, singleResponseDto.PropertyInfoListOfDto);
                ShowGreenMessage(singleResponseDto.Message);
            }
            else
            {
                ShowRedMessage(singleResponseDto.Message);
            }
        }

        public static void ShowListResponse<TReadDto>(ListResponseDto<TReadDto> listResponseDto)
        {
            Console.WriteLine();
            ShowHeading("Response");

            if (listResponseDto.IsSuccessful)
            {
                ShowTable(listResponseDto.List, listResponseDto.PropertyInfoListOfDto);
                ShowGreenMessage(listResponseDto.Message);
            }
            else
            {
                ShowRedMessage(listResponseDto.Message);
            }
        }

        public static void ShowPagedResponse<TReadDto>(PagedResponseDto<TReadDto> pagedResponseDto)
        {
            Console.WriteLine();
            ShowHeading("Response");

            if (pagedResponseDto.IsSuccessful)
            {
                Console.WriteLine($"Page index: {pagedResponseDto.PagedList.PageIndex}");
                Console.WriteLine($"Page size: {pagedResponseDto.PagedList.PageSize}");
                Console.WriteLine($"Total count: {pagedResponseDto.PagedList.TotalCount}");
                Console.WriteLine($"Total pages: {pagedResponseDto.PagedList.TotalPages}");
                Console.WriteLine($"Has previous: {pagedResponseDto.PagedList.HasPrevious}");
                Console.WriteLine($"Has next: {pagedResponseDto.PagedList.HasNext}");
                Console.WriteLine();

                ShowTable(pagedResponseDto.PagedList.Subset, pagedResponseDto.PropertyInfoListOfDto);
                ShowGreenMessage(pagedResponseDto.Message);
            }
            else
            {
                ShowRedMessage(pagedResponseDto.Message);
            }
        }

        public static void ShowHeading(string headingText)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < headingText.Length + 1; i++)
            {
                stringBuilder.Append(DividingBarChar);
            }

            ShowYellowMessage(stringBuilder.ToString());
            ShowYellowMessage(headingText);
            ShowYellowMessage(stringBuilder.ToString());
            Console.WriteLine();
        }

        private static void ShowSingleData<TReadDto>(TReadDto data, IEnumerable<PropertyInfoDto> propertyInfoList)
        {
            if (propertyInfoList.IsNotNullAndNotEmpty())
            {
                foreach (var propertyInfo in propertyInfoList)
                {
                    Console.WriteLine($"{propertyInfo.DisplayName}: {data.GetPropertyValue(propertyInfo.PropertyName)}");
                }
            }
            else
            {
                Console.WriteLine($"Data: {data}");
            }

            Console.WriteLine();
        }

        private static void ShowTable<TReadDto>(IEnumerable<TReadDto> list, IEnumerable<PropertyInfoDto> propertyInfoList)
        {
            if (propertyInfoList.IsNotNullAndNotEmpty())
            {
                var consoleTable = new ConsoleTable(propertyInfoList.Select(x => x.DisplayName).ToArray());

                List<object> values = new List<object>();

                foreach (var item in list)
                {
                    foreach (var propertyInfo in propertyInfoList)
                    {
                        values.Add(item.GetPropertyValue(propertyInfo.PropertyName));
                    }

                    consoleTable.AddRow(values.ToArray());
                    values.Clear();
                }

                consoleTable.Write();
            }
            else
            {
                var consoleTable = new ConsoleTable("Data");

                foreach (var item in list)
                {
                    consoleTable.AddRow(item);
                }

                consoleTable.Write();
            }

            Console.WriteLine();
        }

        public static void ShowPressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowEnumValuesAsMenu<TEnum>() where TEnum : struct
        {
            Array enumArray = Enum.GetValues(typeof(TEnum));

            foreach (TEnum item in enumArray)
            {
                Console.WriteLine($"[{(int)(object)item}] {item.GetDescription()}");
            }

            Console.WriteLine();
        }

        public static async Task RunWithTryCatchAsync(Func<Task> func, string errorMessage)
        {
            try
            {
                await func();
            }
            catch (Exception)
            {
                ShowRedMessage(errorMessage);
            }
        }
    }
}
