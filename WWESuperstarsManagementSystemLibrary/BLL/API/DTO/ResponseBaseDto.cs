namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public abstract class ResponseBaseDto
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
