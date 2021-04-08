using System;

namespace BlaseballStlats.Models
{
    public interface IBlaseballData
    {
        Guid Id { get; set; }
        DateTimeOffset ValidFrom { get; set; }
        DateTimeOffset? ValidTo { get; set; }
    }
}