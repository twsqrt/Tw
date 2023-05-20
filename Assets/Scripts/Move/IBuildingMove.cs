
public interface IBuildingMove : IMove
{
    BuildingInfo BuildingInfo { get; set; }
    BuildingFactory BuildingFactory { get; set; }
}