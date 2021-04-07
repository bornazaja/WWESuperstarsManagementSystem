using RestSharp;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.API.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.Implementations
{
    public class GenericApi<TSaveDto, TReadDto> : IGenericApi<TSaveDto, TReadDto> where TSaveDto : class where TReadDto : class
    {
        protected const string BaseUrl = "http://localhost:50000";
        protected readonly string _modelName;

        public GenericApi()
        {
            _modelName = typeof(TSaveDto).Name.Replace("SaveDto", string.Empty).ToLower();
        }

        public async Task<SaveResponseDto<TReadDto>> AddAsync(TSaveDto saveDto)
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}", Method.POST).AddJsonBody(saveDto);
            return await client.PostAsync<SaveResponseDto<TReadDto>>(request);
        }

        public async Task<SingleResponseDto<int>> CountAsync()
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}/count", Method.GET);
            return await client.GetAsync<SingleResponseDto<int>>(request);
        }

        public async Task<SingleResponseDto<int>> DeleteAsync(int id)
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}/{id}", Method.DELETE);
            return await client.DeleteAsync<SingleResponseDto<int>>(request);
        }

        public async Task<ListResponseDto<TReadDto>> GetAllAsync()
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}", Method.GET);
            return await client.GetAsync<ListResponseDto<TReadDto>>(request);
        }

        public async Task<PagedResponseDto<TReadDto>> GetAllAsync(QueryCriteriaRequestDto queryCriteriaRequestDto)
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}/pagedlist", Method.GET);
            request.AddParameter(nameof(QueryCriteriaRequestDto.PropertiesToSearch), queryCriteriaRequestDto.PropertiesToSearch);
            request.AddParameter(nameof(QueryCriteriaRequestDto.SearchTerm), queryCriteriaRequestDto.SearchTerm);
            request.AddParameter(nameof(QueryCriteriaRequestDto.PropertyNameToSort), queryCriteriaRequestDto.PropertyNameToSort);
            request.AddParameter(nameof(QueryCriteriaRequestDto.SortDirection), queryCriteriaRequestDto.SortDirection);
            request.AddParameter(nameof(QueryCriteriaRequestDto.PageIndex), queryCriteriaRequestDto.PageIndex);
            request.AddParameter(nameof(QueryCriteriaRequestDto.PageSize), queryCriteriaRequestDto.PageSize);

            return await client.GetAsync<PagedResponseDto<TReadDto>>(request);
        }

        public async Task<SingleResponseDto<TReadDto>> GetByIDAsync(int id)
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}/{id}", Method.GET);
            return await client.GetAsync<SingleResponseDto<TReadDto>>(request);
        }

        public async Task<SaveResponseDto<TReadDto>> UpdateAsync(int id, TSaveDto saveDto)
        {
            var client = new RestClient(BaseUrl);
            client.ThrowOnAnyError = true;

            var request = new RestRequest($"api/{_modelName}/{id}", Method.PUT).AddJsonBody(saveDto);
            return await client.PutAsync<SaveResponseDto<TReadDto>>(request);
        }
    }
}
