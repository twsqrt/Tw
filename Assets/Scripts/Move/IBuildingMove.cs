
public interface IBuildingMove : IMove
{
    MapTileBuildingType BuildingType { get; set; }
    MapTileBuildingFactory BuildingFactory { get; set; }
}