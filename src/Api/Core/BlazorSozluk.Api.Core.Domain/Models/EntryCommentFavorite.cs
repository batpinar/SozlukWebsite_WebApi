using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Core.Domain.Models;

public class EntryCommentFavorite : BaseEntity
{
    public Guid EntryCommentId { get; set; }
    public Guid CreatedById { get; set; }
    public virtual EntryComment EntryComments { get; set; }
    public virtual User CreatedUser { get; set; }
}
