using HeroClix.Maps.Enums;

namespace HeroClix.Maps
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
