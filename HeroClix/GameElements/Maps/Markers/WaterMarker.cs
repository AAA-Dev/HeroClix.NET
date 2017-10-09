using HeroClix.Maps.Enums;

namespace HeroClix.Maps
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
