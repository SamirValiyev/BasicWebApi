using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Data.Common
{
    public interface IEntityBase
    {
        public int Id { get; set; }

    }
}
