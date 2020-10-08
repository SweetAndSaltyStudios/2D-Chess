using System.Collections;

namespace Sweet_And_Salty_Studios
{
    public class LocalMultiplayerGame : IGame
    {
        private Board _board = default;
        private Player _player_1 = default;
        private Player _player_2 = default;

        public LocalMultiplayerGame(Board board, Player player_1, Player player_2)
        {
            _board = board;
            _player_1 = player_1;
            _player_2 = player_2;
        }

        public IEnumerator ISetup()
        {
            // We need to yield so boards grid layout can update cell display objects position...
            yield return null;

            _board.PlacePieces(6, 7, _player_1.Pieces);
            _board.PlacePieces(1, 0, _player_2.Pieces);

            yield return null;
        }

        public IEnumerator IStartGame()
        {
            yield return null;
        }

        public IEnumerator IExecuteGame()
        {
            yield return null;
        }

        public IEnumerator IEndGame()
        {
            yield return null;
        }
    }
}