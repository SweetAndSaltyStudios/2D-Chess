using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public enum COLOR_TYPE
    {
        WHITE,
        BLACK
    }

    public class Board
    {
        private readonly Vector2Int _size = default;
        private readonly BoardDisplay _boardDisplay = default;

        private Cell[,] cells = default;

        public Board(Vector2Int size, BoardDisplay boardDisplay)
        {
            _size = size;
            _boardDisplay = boardDisplay;

            cells = new Cell[size.x, size.y];

            var coordinates = Vector2Int.zero;

            for(var x = 0; x < size.x; x++)
            {
                for(var y = 0; y < size.y; y++)
                {
                    var cellDisplay = ResourceManager.Instance.SpawnInstance<CellDisplay>($"Cell {x} , {y}", _boardDisplay.transform);

                    cellDisplay.Image.sprite = (x + y) % 2 == 0 ? ResourceManager.Instance.WhiteCell : ResourceManager.Instance.BlackCell;

                    coordinates.x = x;
                    coordinates.y = y;

                    cells[x, y] = new Cell(coordinates, cellDisplay);
                }
            }
        }
    }
}