using System;
using System.Collections.Generic;

namespace Sweet_And_Salty_Studios
{
    public class Player
    {
        private readonly COLOR_TYPE _colorType = default;
        private readonly Piece[] _pieces = default;
        private readonly PlayerDisplay _playerDisplay = default;

        public Player(COLOR_TYPE colorType, Type[] pieceMap, PlayerDisplay playerDisplay)
        {
            _colorType = colorType;
            _playerDisplay = playerDisplay;

            CreatePieces(_colorType, pieceMap);
        }

        private Piece[] CreatePieces(COLOR_TYPE colorType, Type[] pieceMap)
        {
            var pieces = new List<Piece>();

            foreach(var pieceType in pieceMap)
            {
                var pieceDisplay = ResourceManager.Instance.SpawnInstance<PieceDisplay>(pieceType.Name, _playerDisplay.transform);
                var newPiece = new Piece(pieceDisplay, colorType);

                pieces.Add(newPiece);
            }

            return pieces.ToArray();
        }
    }
}