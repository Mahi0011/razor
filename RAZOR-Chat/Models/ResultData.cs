using Microsoft.AspNetCore.Mvc;

namespace RAZOR_Chat.Models
{
    public class Response<T>
    {
        public bool Success {  get; set; }
        public T Data { get; set; }
        public string Messege { get; set; }
        public static Response<T> setResponse(bool success, T data, string messege)
        {
            Response<T> response = new Response<T>()
            {
                Success = success,
                Data = data,
                Messege = messege
            };
            return response;
        }
    }
    public class ResultData<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Messege { get; set; }
    }
}
