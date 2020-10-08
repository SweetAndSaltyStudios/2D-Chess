using System;
using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _playArea = default;

        private IGame _currentGame = default;

        private Coroutine _currentlyRunningGame_Coroutine = default;

        private void Start() 
        {
             _currentGame = CreateGame<LocalMultiplayerGame>();

            if(_currentlyRunningGame_Coroutine != null)
            {
                Debug.LogWarning("Game is already running!");
                return;
            }

            _currentlyRunningGame_Coroutine = StartCoroutine(IRunGame(_currentGame));
        }

        private IEnumerator IRunGame(IGame game)
        {
            yield return game.ISetup();

            yield return game.IStartGame();

            yield return game.IExecuteGame();
         
            yield return game.IEndGame();

            _currentlyRunningGame_Coroutine = null;
        }

        private IGame CreateGame<T>() where T : IGame
        {
            // TODO: Make this more generic

            var board = new Board( Vector2Int.one * 8, ResourceManager.Instance.SpawnInstance<BoardDisplay>("Board", _playArea));

            var pieceMap = new Type[]
            {
                typeof(Pawn), typeof(Pawn), typeof(Pawn),typeof(Pawn), typeof(Pawn), typeof(Pawn), typeof(Pawn), typeof(Pawn),
                typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook)
            };

            var player_1 = new Player(
                COLOR_TYPE.WHITE,
                pieceMap,
                ResourceManager.Instance.SpawnInstance<PlayerDisplay>("Player 1", _playArea));

            var player_2 = new Player(
                COLOR_TYPE.BLACK,
                pieceMap,
                ResourceManager.Instance.SpawnInstance<PlayerDisplay>("Player 2", _playArea));

            return new LocalMultiplayerGame(board, player_1, player_2);
        }
    }
}