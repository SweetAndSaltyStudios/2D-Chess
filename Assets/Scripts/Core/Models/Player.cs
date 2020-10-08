using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Player
    {
        public COLOR_TYPE ColorType { get; } = default;

        public Piece[] Pieces { get; } = default;

        public PlayerDisplay PlayerDisplay { get; } = default;

        public Player(Board board, COLOR_TYPE colorType, Type[] pieceMap, PlayerDisplay playerDisplay)
        {
            ColorType = colorType;
            PlayerDisplay = playerDisplay;

            Pieces = CreatePieces(board, ColorType, pieceMap);
        }

        private Piece[] CreatePieces(Board board, COLOR_TYPE colorType, Type[] pieceMap)
        {
            var pieces = new List<Piece>();

            foreach(var pieceType in pieceMap)
            {
                var pieceDisplay = ResourceManager.Instance.SpawnInstance<PieceDisplay>(pieceType.Name, PlayerDisplay.transform);

                pieceDisplay.Image.sprite = ResourceManager.Instance.GetSpriteByType(pieceType, ColorType);

                // TODO: :(

                Piece newPiece = default;

                if(pieceType == typeof(Pawn)) newPiece = new Pawn(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.up,
                });

                if(pieceType == typeof(Rook)) newPiece = new Rook(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.up * board.Size.y,
                    Vector2Int.right * board.Size.x,
                    Vector2Int.down * board.Size.y,
                    Vector2Int.left * board.Size.x,
                });

                if(pieceType == typeof(Knight)) newPiece = new Knight(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.up * board.Size.y,
                    Vector2Int.right * board.Size.x + Vector2Int.up * board.Size.y,
                    Vector2Int.right * board.Size.x,
                    Vector2Int.right * board.Size.x + Vector2Int.down * board.Size.y,
                    Vector2Int.down * board.Size.y,
                    Vector2Int.down * board.Size.x + Vector2Int.left * board.Size.y,
                    Vector2Int.left * board.Size.x,
                    Vector2Int.left * board.Size.x + Vector2Int.up * board.Size.y,
                });

                if(pieceType == typeof(Bishop)) newPiece = new Bishop(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.right + Vector2Int.up,
                    Vector2Int.right + Vector2Int.down,
                    Vector2Int.down + Vector2Int.left,
                    Vector2Int.left + Vector2Int.up
                });

                if(pieceType == typeof(Queen)) newPiece = new Queen(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.up * board.Size.y,
                    Vector2Int.right * board.Size.x + Vector2Int.up * board.Size.y,
                    Vector2Int.right * board.Size.x,
                    Vector2Int.right * board.Size.x + Vector2Int.down * board.Size.y,
                    Vector2Int.down * board.Size.y,
                    Vector2Int.down * board.Size.x + Vector2Int.left * board.Size.y,
                    Vector2Int.left * board.Size.x,
                    Vector2Int.left * board.Size.x + Vector2Int.up * board.Size.y,
                });

                if(pieceType == typeof(King)) newPiece = new King(this, board, pieceDisplay, colorType, new Vector2Int[]
                {
                    Vector2Int.up,
                    Vector2Int.right + Vector2Int.up,
                    Vector2Int.right,
                    Vector2Int.right + Vector2Int.down,
                    Vector2Int.down,
                    Vector2Int.down + Vector2Int.left,
                    Vector2Int.left,
                    Vector2Int.left + Vector2Int.up
                });

                pieces.Add(newPiece);
            }

            return pieces.ToArray();
        }
    }
}