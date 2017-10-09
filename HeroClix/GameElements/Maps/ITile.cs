using HeroClix.GameElements;
using HeroClix.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Maps
{
    public interface ITile
    {
        Tuple<List<BorderType>, List<BorderType>, List<BorderType>, List<BorderType>> GetBorderDetails();

        List<IGamePiece> GetGamePieces();

        TerrainType GetTerrainType();

        void AddGamePiece(IGamePiece element);

        void AddMarker(IMarker marker);

        IMarker RemoveMarker();
    }
}
