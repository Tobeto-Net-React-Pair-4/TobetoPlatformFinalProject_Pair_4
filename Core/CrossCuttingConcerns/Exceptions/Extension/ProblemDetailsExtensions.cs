using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.Extension
{
    public static class ProblemDetailsExtensions
    {
        public static string AsJson<TProblemDetail>(this TProblemDetail details)
            where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(details);
    }
}
