namespace Invidux_Data.Dtos.Response
{
    public class Response<T>
    {
        public string Code { get; set; }
        public bool Successful { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
