using System;
using System.Collections.Generic;

namespace Sweet_And_Salty_Studios
{
    public class Player
    {
        public COLOR_TYPE ColorType { get; } = default;

        public Piece[] Pieces { get; } = default;

        public PlayerDisplay PlayerDisplay { get; } = default;

        public Player(COLOR_TYPE colorType, Type[] pieceMap, PlayerDisplay playerDisplay)
        {
            ColorType = colorType;
            PlayerDisplay = playerDisplay;

            Pieces = CreatePieces(ColorType, pieceMap);
        }

        private Piece[] CreatePieces(COLOR_TYPE colorType, Type[] pieceMap)
        {
            var pieces = new List<Piece>();

            foreach(var pieceType in pieceMap)
            {
                var pieceDisplay = ResourceManager.Instance.SpawnInstance<PieceDisplay>(pieceType.Name, PlayerDisplay.transform);

                pieceDisplay.Image.sprite = ResourceManager.Instance.GetSpriteByType(pieceType, ColorType);

                var newPiece = new Piece(pieceDisplay, colorType);

                pieces.Add(newPiece);
            }

            return pieces.ToArray();
        }
    }
}