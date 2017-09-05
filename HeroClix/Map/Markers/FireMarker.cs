
namespace HeroClix.Map
{
    public class FireMarker : Marker
    {
        public FireMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Blocking;
        }
    }
}
