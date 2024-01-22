using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.OperationClaim.Requests
{
    public class CreateOperationClaimRequest
    {
        public string Name { get; set; }
    }
}
