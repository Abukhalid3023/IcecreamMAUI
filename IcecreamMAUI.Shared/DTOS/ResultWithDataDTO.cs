namespace IcecreamMAUI.Shared.DTOS
{
    public record ResultWithDataDTO<TData>(bool IsSuccess, TData Data, string? ErrorMessage)
    {
        public static ResultWithDataDTO<TData> Success(TData data) => new(true,data, null);

        public static ResultWithDataDTO<TData> Failure(string? ErrorMessage) => new(false, default, ErrorMessage);
    }
}
