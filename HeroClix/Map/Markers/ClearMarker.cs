namespace HeroClix.Map
{
    public class ClearMarker : Marker
    {
        public ClearMarker(IGameElement creator)
            : base(creator)
        {
            this.terrainType = TerrainType.Clear;
        }
    }
}
