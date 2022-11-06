using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcLibrary
{
    public enum BookStatusEnum
    {
        [Description("Available")]
        Available,
        [Description("Unavailable")]
        Unavailable
    }
}
