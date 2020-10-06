using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class GameManager : MonoBehaviour
    {
        private Board _board = default;
        private Player _player_1 = default;
        private Player _player_2 = default;

        private void Start()
        {
            _board = CreateBoard();
            _player_1 = CreatePlayer(COLOR_TYPE.WHITE, "Player 1");
            _player_2 = CreatePlayer(COLOR_TYPE.BLACK, "Player 2");
        }

        private Board CreateBoard()
        {
            var boardDisplay = ResourceManager.Instance.SpawnInstance<BoardDisplay>("Board", transform);
            boardDisplay.RectTransform.anchoredPosition = Vector2.zero;

            var size = Vector2Int.one * 8;
            return new Board(size, boardDisplay);
        }

        private Player CreatePlayer(COLOR_TYPE colorType, string name)
        {

            var pieceMap = new Type[]
            {
                typeof(Pawn), typeof(Pawn), typeof(Pawn),typeof(Pawn), typeof(Pawn), typeof(Pawn), typeof(Pawn), typeof(Pawn),
                typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook)
            };

            var pieces = CreatePieces(colorType, pieceMap);
            var playerDisplay = ResourceManager.Instance.SpawnInstance<PlayerDisplay>(name);

            // TODO: Seperate player piece generation...
            var player = new Player(pieces, playerDisplay);

            return player;
        }

        private Piece[] CreatePieces(COLOR_TYPE colorType, Type[] pieceMap)
        {
            var pieces = new List<Piece>();

            foreach(var pieceType in pieceMap)
            {
                var pieceDisplay = ResourceManager.Instance.SpawnInstance<PieceDisplay>(pieceType.Name);
                var newPiece = new Piece(pieceDisplay, colorType); 

                pieces.Add(newPiece);
            }

            return pieces.ToArray();
        }
    }
}