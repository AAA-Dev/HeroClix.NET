
namespace HeroClix.Map
{
    public class SmokeMarker : Marker
    {
        public SmokeMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Hindering;
        }
    }
}
