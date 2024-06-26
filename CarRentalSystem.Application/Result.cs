﻿namespace CarRentalSystem.Application;

using static Domain.Exceptions.ApplicationExceptionConstants.ResultExceptionMessages;

public class Result
{
    private readonly List<string> errors;

    internal Result(
        bool succeeded,
        List<string> errors)
    {
        this.Succeeded = succeeded;

        this.errors = errors;
    }

    public bool Succeeded { get; }

    public List<string> Errors
        => this.Succeeded
            ? new List<string>()
            : this.errors;

    public static Result Success
        => new Result(true, new List<string>());

    public static Result Failure(IEnumerable<string> errors)
        => new Result(false, errors.ToList());

    public static implicit operator Result(string error)
        => Failure([error]);

    public static implicit operator Result(List<string> errors)
        => Failure(errors);

    public static implicit operator Result(bool success)
        => success ? Success : Failure(["Unsuccessful operation."]);

    public static implicit operator bool(Result result)
        => result.Succeeded;
}

public class Result<TData> : Result
{
    private readonly TData data;

    private Result(bool succeeded, TData data, List<string> errors)
        : base(succeeded, errors)
        => this.data = data;

    public TData Data
        => this.Succeeded
            ? this.data
            : throw new InvalidOperationException(string.Format(
                ResultDataNotSupportedWithFailedResultExceptionMessage,
                nameof(this.Data), 
                this.Errors));

    public static Result<TData> SuccessWith(TData data)
        => new Result<TData>(true, data, new List<string>());

    public static Result<TData> Failure(List<string> errors)
        => new Result<TData>(false, default(TData)!, errors);

    public static implicit operator Result<TData>(string error)
        => Failure([error]);

    public static implicit operator Result<TData>(List<string> errors)
        => Failure(errors);

    public static implicit operator Result<TData>(TData data)
        => SuccessWith(data);

    public static implicit operator bool(Result<TData> result)
        => result.Succeeded;
}