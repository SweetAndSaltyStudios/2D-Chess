namespace Sweet_And_Salty_Studios
{
    public class Piece
    {
        public Player Owner { get; } = default;
        public PieceDisplay PieceDisplay { get; } = default;
        public COLOR_TYPE Color { get; } = default;
        
        public Piece(PieceDisplay pieceDisplay, COLOR_TYPE color)
        {
            PieceDisplay = pieceDisplay;
            Color = color;
        }

    }
}