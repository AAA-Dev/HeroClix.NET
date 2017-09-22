using HeroClix.Map.Enums;

namespace HeroClix.Map
{
    public class ClearMarker : Marker
    {
        public ClearMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Clear";
            this.terrainType = TerrainType.Clear;
        }
    }
}
