
namespace HeroClix.Map
{
    public class BarrierMarker : Marker
    {
        public BarrierMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Blocking;
        }
    }
}
