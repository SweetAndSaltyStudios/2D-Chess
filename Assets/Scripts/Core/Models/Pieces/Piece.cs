using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class Piece
    {
        public Player Owner { get; } = default;
        public PieceDisplay PieceDisplay { get; } = default;
        public COLOR_TYPE Color { get; } = default;
        public Vector2Int[] MoveDirections { get; } = default;
        public Vector2Int Coordinates { get; set; } = default;

        private Cell[] _validCells = default;

        public Piece(Player owner, Board board, PieceDisplay pieceDisplay, COLOR_TYPE color, Vector2Int[] moveDirections)
        {
            Owner = owner;
            PieceDisplay = pieceDisplay;
            Color = color;
            MoveDirections = moveDirections;

            PieceDisplay.OnPointerDown_Event.AddListener(() =>
            {
                _validCells = board.GetValidCells(this, MoveDirections);

                foreach(var cell in _validCells)
                {
                    cell.CellDisplay.Image.color = UnityEngine.Color.red;
                }
            });
            
            PieceDisplay.OnPointerUp_Event.AddListener(() =>
            {
                if(_validCells == null || _validCells.Length == 0) return;

                foreach(var cell in _validCells)
                {
                    cell.CellDisplay.Image.color = UnityEngine.Color.white;
                }
            });
        }
    }
}