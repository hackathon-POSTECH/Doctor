namespace DOCTOR.APPLICATION;

public class ResultPattern<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string[]? ErroMenssage { get; set; }


    public static ResultPattern<T> ToSuccess(T? data)
        => new ResultPattern<T> { Data = data, Success = true };

    public static ResultPattern<T> ToError(string[]? data = null)
    => new ResultPattern<T> { ErroMenssage = data, Success = false };

}
