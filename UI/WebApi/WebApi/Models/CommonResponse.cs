namespace SecretMadonna.NEMS.UI.WebApi.Models
{
    public class CommonResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }
    public class CommonResponse<T> : CommonResponse
    {
        public T Data { get; set; }
    }
}