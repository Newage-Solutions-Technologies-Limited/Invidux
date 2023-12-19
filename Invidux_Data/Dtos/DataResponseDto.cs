﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Invidux_Data.Dtos
{
    // Abstract class for data response
    public abstract class DataResponseAbstractDTO
    {
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DataResponseArrayDTO<T> : DataResponseAbstractDTO
    {
        /// <summary>
        /// The items being returned
        /// </summary>
        public IEnumerable<T> Data { get; set; }
        /// <summary>
        /// The page of items being returned
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The size of items in each page
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// The total number of items to be returned
        /// </summary>
        public int Count { get; set; }

        public DataResponseArrayDTO(IEnumerable<T> items,
                                    int count,
                                    int page = 1,
                                    int size = 50,
                                    HttpStatusCode statusCode = HttpStatusCode.OK,
                                    bool isSuccess = true)
        {
            Data = items;
            Page = page;
            Status = statusCode;
            IsSuccess = isSuccess;
            Size = size < 1 ? 50 : size;
            Count = count;// < items.Count() ? items.Count() : count;

            Size = Size > Count ? Count : Size;
        }
    }

    public class DataResponseListDTO<T> : DataResponseAbstractDTO
    {
        /// <summary>
        /// The items being returned
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        public DataResponseListDTO(IEnumerable<T> items,
                                    HttpStatusCode statusCode = HttpStatusCode.OK,
                                    bool isSuccess = true)
        {
            Data = items;
            Status = statusCode;
            IsSuccess = isSuccess;
        }
    }

    public class DataResponseDTO<T> : DataResponseAbstractDTO
    {
        public T Data { get; set; }

        public DataResponseDTO(T data,
                               HttpStatusCode statusCode = HttpStatusCode.OK,
                               bool isSuccess = true)
        {
            Data = data;
            Status = statusCode;
            IsSuccess = isSuccess;
        }
    }

    public class ErrorResponseDTO : DataResponseAbstractDTO
    {
        public string ErrorMessages { get; set; }

        public ErrorResponseDTO(HttpStatusCode statusCode, string errors)
        {
            Status = statusCode;
            ErrorMessages = errors;
            IsSuccess = false;
        }
    }

    public class ModelStateErrorResponseDTO : DataResponseAbstractDTO
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public ModelStateErrorResponseDTO(HttpStatusCode statusCode, ModelStateDictionary modelStateErrors)
        {
            Status = statusCode;
            ErrorMessages.AddRange(modelStateErrors.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            IsSuccess = false;
        }
    }

    /// <summary>
	/// Limits a model string property to a predefined set of values
	/// </summary>
	public class StringRangeAttribute : ValidationAttribute
    {
        public string[]? AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }
}
