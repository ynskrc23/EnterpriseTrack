using Core.DTOs.Region;

namespace Core.DTOs.Territory
{
    public class TerritoryListDto : BaseDto
    {
        public int Id { get; set; }
        public string TerritoryDescription { get; set; }
        public int? RegionId { get; set; }
        public RegionListDto Region { get; set; }
    }
}
