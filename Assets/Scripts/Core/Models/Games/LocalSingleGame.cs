using System;
using System.Collections;

namespace Sweet_And_Salty_Studios
{
    public class LocalSingleGame : IGame
    {
        private Board _board = default;
        private Player _player_1 = default;
        private Player _player_2 = default;

        public LocalSingleGame(Board board, Player player_1, Player player_2)
        {
            _board = board;
            _player_1 = player_1;
            _player_2 = player_2;
        }

        public IEnumerator IEndGame()
        {
            throw new NotImplementedException();
        }

        public IEnumerator IExecuteGame()
        {
            throw new NotImplementedException();
        }

        public IEnumerator ISetup()
        {
            throw new NotImplementedException();
        }

        public IEnumerator IStartGame()
        {
            throw new NotImplementedException();
        }
    }
}