namespace IsSistemCase.Core.DTOs.ResponseDTOs
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        bool HasError { get; set; }
        List<string> ErrorMessages { get; set; }
    }
}
