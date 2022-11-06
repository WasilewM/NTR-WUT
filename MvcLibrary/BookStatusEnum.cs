using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcLibrary
{
    public enum BookStatusEnum
    {
        [Description("Available")]
        Available,
        [Description("Reserved")]
        Reserved,
        [Description("Lent")]
        Lent
    }
}
