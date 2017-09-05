namespace HeroClix.Map
{
    public class DebrisMarker : Marker
    {
        public DebrisMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Hindering;
        }
    }
}
