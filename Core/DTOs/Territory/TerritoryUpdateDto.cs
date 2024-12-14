using Core.DTOs.Region;

namespace Core.DTOs.Territory
{
    public class TerritoryUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string TerritoryDescription { get; set; }
        public int? RegionId { get; set; }
    }
}
