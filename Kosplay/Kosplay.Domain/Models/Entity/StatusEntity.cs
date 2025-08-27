
namespace Kosplay.Domain.Models.Entity
{
    public class StatusEntity  :BaseEntity
    {
        public string Descricao { get; set; }
        public string Tag { get; set; }
        public IEnumerable<ProductEntity> Products { get; set; }
    }
}
