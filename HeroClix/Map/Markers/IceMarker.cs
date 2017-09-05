namespace HeroClix.Map
{
    public class IceMarker : Marker
    {
        public IceMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Ice";
            this.terrainType = TerrainType.Blocking;
        }
    }
}
