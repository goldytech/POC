using System;

namespace DICtorParam.Infrastructure
{
    public class Result<TSuccess, TFailure>
    {

        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public TSuccess SuccessValue { get; private set; }
        public TFailure FailureValue { get; private set; }
        public bool IsSuccess { get; }

        public static Result<TSuccess, TFailure> SucceedWith(TSuccess value) =>
            new Result<TSuccess, TFailure>(true)
            {
                SuccessValue = value
            };

        public static Result<TSuccess, TFailure> FailWith(TFailure value) =>
            new Result<TSuccess, TFailure>(false)
            {
                FailureValue = value
            };

       


    }
}