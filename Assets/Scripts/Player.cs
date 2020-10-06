namespace Sweet_And_Salty_Studios
{
    public class Player
    {
        private Piece[] _pieces = default;
        private PlayerDisplay _playerDisplay = default;

        public Player(Piece[] pieces, PlayerDisplay playerDisplay)
        {
            _pieces = pieces;
            _playerDisplay = playerDisplay;
        }
    }
}