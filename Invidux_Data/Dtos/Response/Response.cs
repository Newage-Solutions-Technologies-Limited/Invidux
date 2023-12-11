﻿namespace Invidux_Data.Dtos.Response
{
    public class Response<T>
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }

    public class ResponseArrayDTO<T>
    {
        public bool Successful { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int totalNumber { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}