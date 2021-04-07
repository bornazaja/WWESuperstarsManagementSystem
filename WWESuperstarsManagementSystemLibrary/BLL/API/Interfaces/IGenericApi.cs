using System.Threading.Tasks;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.Interfaces
{
    public interface IGenericApi<TSaveDto, TReadDto> where TSaveDto : class where TReadDto : class
    {
        Task<SaveResponseDto<TReadDto>> AddAsync(TSaveDto saveDto);
        Task<SaveResponseDto<TReadDto>> UpdateAsync(int id, TSaveDto saveDto);
        Task<SingleResponseDto<int>> DeleteAsync(int id);
        Task<SingleResponseDto<TReadDto>> GetByIDAsync(int id);
        Task<ListResponseDto<TReadDto>> GetAllAsync();
        Task<PagedResponseDto<TReadDto>> GetAllAsync(QueryCriteriaRequestDto queryCriteriaRequestDto);
        Task<SingleResponseDto<int>> CountAsync();
    }
}
