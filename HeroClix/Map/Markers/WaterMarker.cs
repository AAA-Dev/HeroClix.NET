
namespace HeroClix.Map
{
    public class WaterMarker : Marker
    {
        public WaterMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Water;
        }
    }
}
