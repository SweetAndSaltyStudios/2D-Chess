namespace Sweet_And_Salty_Studios
{
    public class Piece
    {
        private readonly Player _owner = default;
        private readonly PieceDisplay _pieceDisplay = default;
        private readonly COLOR_TYPE color = default;

        public Piece(PieceDisplay pieceDisplay, COLOR_TYPE color)
        {
            _pieceDisplay = pieceDisplay;
            this.color = color;
        }
    }
}