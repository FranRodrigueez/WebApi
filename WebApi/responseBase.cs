using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class responseBase
    {
        [NotMapped]
        public string? message;

        [NotMapped]
        public int? status;
    }
}
