using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Player
    {
        public ATTACK_DIRECTION AttackDirection { get; } = default;
        public COLOR_TYPE ColorType { get; } = default;

        public Piece[] Pieces { get; } = default;

        public PlayerDisplay PlayerDisplay { get; } = default;

        public Player(ATTACK_DIRECTION attakDirection, Board board, COLOR_TYPE colorType, Type[] pieceMap, PlayerDisplay playerDisplay)
        {
            AttackDirection = attakDirection;
            ColorType = colorType;
            PlayerDisplay = playerDisplay;

            Pieces = CreatePieces(attakDirection, board, colorType, pieceMap);
        }

        private Piece[] CreatePieces(ATTACK_DIRECTION attackDirection, Board board, COLOR_TYPE colorType, Type[] pieceMap)
        {
            var pieces = new List<Piece>();

            foreach(var pieceType in pieceMap)
            {
                var pieceDisplay = ResourceManager.Instance.SpawnInstance<PieceDisplay>(pieceType.Name, PlayerDisplay.transform);
                pieceDisplay.Image.sprite = ResourceManager.Instance.GetSpriteByType(pieceType, ColorType);

                // TODO: :(

                Piece newPiece = default;

                if(pieceType == typeof(Pawn)) newPiece = new Pawn(
                    this,
                    board,
                    pieceDisplay,
                    colorType,
                    new PieceMove(1, new Vector2Int[]
                    {
                        Vector2Int.up * (int)AttackDirection
                    })); 
                

                if(pieceType == typeof(Rook)) newPiece = new Rook(
                    this, 
                    board, 
                    pieceDisplay, 
                    colorType, new PieceMove(8, new Vector2Int[]
                    {
                        Vector2Int.up,
                        Vector2Int.right,
                        Vector2Int.down,
                        Vector2Int.left,
                    }));

                if(pieceType == typeof(Knight)) newPiece = new Knight(
                    this,
                    board, 
                    pieceDisplay,
                    colorType, 
                    new PieceMove(1, new Vector2Int[]
                    {
                        Vector2Int.up * 2 + Vector2Int.right,
                        Vector2Int.up * 2 + Vector2Int.left,

                        Vector2Int.right * 2 + Vector2Int.up,
                        Vector2Int.right * 2 + Vector2Int.down,

                        Vector2Int.down * 2 + Vector2Int.right,
                        Vector2Int.down * 2 + Vector2Int.left,

                        Vector2Int.left * 2 + Vector2Int.up,
                        Vector2Int.left * 2 + Vector2Int.down
                    }));

                if(pieceType == typeof(Bishop)) newPiece = new Bishop(
                    this, 
                    board, 
                    pieceDisplay, 
                    colorType, 
                    new PieceMove(8, new Vector2Int[]
                    {
                        Vector2Int.right + Vector2Int.up,
                        Vector2Int.right + Vector2Int.down,
                        Vector2Int.down + Vector2Int.left,
                        Vector2Int.left + Vector2Int.up
                    }));

                if(pieceType == typeof(Queen)) newPiece = new Queen(
                    this,
                    board,
                    pieceDisplay,
                    colorType,
                    new PieceMove(8, new Vector2Int[]
                    {
                        Vector2Int.up,
                        Vector2Int.right + Vector2Int.up,
                        Vector2Int.right,
                        Vector2Int.right + Vector2Int.down,
                        Vector2Int.down,
                        Vector2Int.down + Vector2Int.left,
                        Vector2Int.left,
                        Vector2Int.left + Vector2Int.up,
                    }));

                if(pieceType == typeof(King)) newPiece = new King(
                    this,
                    board, 
                    pieceDisplay, 
                    colorType, 
                    new PieceMove(1, new Vector2Int[]
                    {
                        Vector2Int.up,
                        Vector2Int.right + Vector2Int.up,
                        Vector2Int.right,
                        Vector2Int.right + Vector2Int.down,
                        Vector2Int.down,
                        Vector2Int.down + Vector2Int.left,
                        Vector2Int.left,
                        Vector2Int.left + Vector2Int.up
                    }));

                pieces.Add(newPiece);
            }

            return pieces.ToArray();
        }
    }
}