using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Core.Domain.Models;

public class EmailConfirmation : BaseEntity
{
    public string NewEmailAddress { get; set; }
    public string OldEmailAddress { get; set; }

}
