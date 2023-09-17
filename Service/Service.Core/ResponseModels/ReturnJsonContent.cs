using System.Collections;
using System.Net;
using Domain.Core.Bus;

namespace Service.Core.ResponseModels;

public class ReturnJsonContent<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public int DataCount => GetDataCount(Data);
    public T Data { get; set; }
    public dynamic? ValidationErrors { get; set; }

    public ReturnJsonContent(T data, HttpStatusCode statusCode, bool success, dynamic? validationErrors = null)
    {
        Data = data;
        StatusCode = statusCode;
        ValidationErrors = validationErrors;
        Success = success;
    }
    
    private int GetDataCount<TR>(TR data)
    {
        if (data is ICollection collection)
            return collection.Count;

        return data != null ? 1 : 0;
    }
}