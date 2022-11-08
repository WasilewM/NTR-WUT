using System.ComponentModel;

namespace MvcLibrary
{
    public enum BookOrderStatusEnum
    {
        [Description("Book Reserved")]
        BookReserved,
        [Description("BookLent")]
        BookLent,
        Finished,
        Cancelled
    }
}
