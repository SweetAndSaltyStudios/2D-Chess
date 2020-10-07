using System.Collections;

namespace Sweet_And_Salty_Studios
{
    public class LocalMultiplayerGame : IGame
    {
        private Board _board = default;
        private Player _player_1 = default;
        private Player _player_2 = default;

        public LocalMultiplayerGame() { }
        public LocalMultiplayerGame(Board board, Player player_1, Player player_2)
        {
            _board = board;
            _player_1 = player_1;
            _player_2 = player_2;
        }

        public IEnumerator IEndGame()
        {
            yield return null;
        }

        public IEnumerator IExecuteGame()
        {
            yield return null;
        }

        public IEnumerator ISetup()
        {
            yield return null;
        }

        public IEnumerator IStartGame()
        {
            yield return null;
        }
    }
}