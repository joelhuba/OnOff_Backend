﻿namespace ToDoList.Core.DTOs.Commons
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
