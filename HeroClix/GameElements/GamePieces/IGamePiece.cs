using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.GameElements
{
    /// <summary>
    /// A game piece is anything that is placed on the map. This includes characters, objects, and markers. 
    /// Markers are not game elements and are not added to your force. (See p.22 for Markers.)
    /// </summary>
    public interface IGamePiece : IGameElement
    {
    }
}
