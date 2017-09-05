namespace HeroClix.Map
{
    public class DebrisMarker : Marker
    {
        public DebrisMarker(IGameElement creator)
            : base(creator)
        {
            this.markerName = "Debris";
            this.terrainType = TerrainType.Hindering;
        }
    }
}
