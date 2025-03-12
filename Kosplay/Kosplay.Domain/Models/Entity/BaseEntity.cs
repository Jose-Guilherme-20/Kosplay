namespace Kosplay.Domain.Models.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Active = true;
        }
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
