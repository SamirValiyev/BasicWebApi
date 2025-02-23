namespace BasicWebApi.Data.Common
{
    public class EntityBase:IEntityBase
    {
        public string Name { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
