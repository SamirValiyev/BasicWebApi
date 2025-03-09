namespace BasicWebApi.Data.Common
{
    public class EntityBase:IEntityBase
    {
        public string Name { get; set; }

        public virtual int Id { get; set; }

    }
}
