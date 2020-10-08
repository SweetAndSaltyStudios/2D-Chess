using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class PieceMove
    {
        public int MoveDistance { get; } = default;
        public Vector2Int[] MoveDirections { get; } = default;

        public PieceMove(int moveDistance, Vector2Int[] moveDirection)
        {
            MoveDistance = moveDistance;
            MoveDirections = moveDirection;
        }
    }
}