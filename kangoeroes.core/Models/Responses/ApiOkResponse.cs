﻿namespace kangoeroes.core.Models.Responses
{
  public class ApiOkResponse : ApiResponse
  {
    public object Result { get; }

    public ApiOkResponse(object result) : base(200)
    {
      Result = result;
    }
  }
}
