using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Bishop : Piece
    {
        public Bishop(Player owner, Board board, PieceDisplay pieceDisplay, COLOR_TYPE color, Vector2Int[] movePositions) : base(owner, board, pieceDisplay, color, movePositions)
        {

        }
    }
}