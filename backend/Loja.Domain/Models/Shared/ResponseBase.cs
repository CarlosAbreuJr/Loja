namespace Loja.Domain.Models.Shared
{
    public class ResponseBase<T> where T : class
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public ResponseBase()
        { }

        public ResponseBase(bool success, T data)
        {
            Success = success;
            Data = data;
        }
    }
}
