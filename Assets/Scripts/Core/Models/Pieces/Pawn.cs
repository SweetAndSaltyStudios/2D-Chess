using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Pawn : Piece
    {
        public Pawn(Player owner, Board board, PieceDisplay pieceDisplay, COLOR_TYPE color, PieceMove pieceMove) : base(owner, board, pieceDisplay, color, pieceMove)
        {

        }
    }
}