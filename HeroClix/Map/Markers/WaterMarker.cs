using HeroClix.Map.Enums;

namespace HeroClix.Map
{
    public class WaterMarker : Marker
    {
        public WaterMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Water";
            this.terrainType = TerrainType.Water;
        }
    }
}
