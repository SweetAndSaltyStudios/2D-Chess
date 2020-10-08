using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Board
    {
        private readonly BoardDisplay _boardDisplay = default;
        private readonly Cell[,] cells = default;

        public Vector2Int Size { get; }

        public Board(Vector2Int size, BoardDisplay boardDisplay)
        {
            Size = size;

            _boardDisplay = boardDisplay;

            cells = new Cell[size.x, size.y];

            var coordinates = Vector2Int.zero;

            for(var x = 0; x < size.x; x++)
            {
                for(var y = 0; y < size.y; y++)
                {
                    var cellDisplay = ResourceManager.Instance.SpawnInstance<CellDisplay>($"Cell {x} , {y}", _boardDisplay.transform);

                    cellDisplay.Image.sprite = (x + y) % 2 == 0 ? ResourceManager.Instance.WhiteCell : ResourceManager.Instance.BlackCell;
                    cellDisplay.CoordinatesText.text = $"({x} , {y})";

                    coordinates.x = x;
                    coordinates.y = y;

                    cells[x, y] = new Cell(coordinates, cellDisplay);
                }
            }
        }

        public Cell[] GetValidCells(Piece piece)
        {
            var cells = new List<Cell>();

            var moveDirections = piece.PieceMove.MoveDirections;
            var moveDistance = piece.PieceMove.MoveDistance;

            for(var i = 0; i < moveDirections.Length; i++)
            {
                for(var j = 1; j <= moveDistance; j++)
                {
                    var targetCoordinates = piece.Coordinates + moveDirections[i] * j;
                    
                    var cell = GetCell(targetCoordinates);

                    if(CheckIfValidMove(cell) == false) continue;

                    cells.Add(cell);
                }
            }

            return cells.ToArray();
        }

        private Cell GetCell(Vector2Int coordinates)
        {
            if(coordinates.x < 0 || coordinates.x >= Size.x || coordinates.y < 0 || coordinates.y >= Size.y) 
            {
                //Debug.LogWarning($"Cell {coordinates} does not exist!");
                return null;
            }


            return cells[coordinates.x, coordinates.y];
        }

        private bool CheckIfValidMove(Cell cell)
        {
            if(cell == null) return false;

            if(cell.IsOccupied) return false;

            return true;
        }

        public void PlacePieces(int pawnColumn, int royaltyColumn, Piece[] pieces)
        {
            for(int i = 0; i < 8; i++)
            {
                pieces[i].Coordinates = new Vector2Int(i, pawnColumn);

                pieces[i].PieceDisplay.transform.position = cells[i, pawnColumn].CellDisplay.transform.position;


                pieces[i + 8].Coordinates = new Vector2Int(i, royaltyColumn);

                pieces[i + 8].PieceDisplay.transform.position = cells[i, royaltyColumn].CellDisplay.transform.position;
            }
        }
    }
}