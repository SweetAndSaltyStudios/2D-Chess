using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Cell
    {
        private readonly Vector2Int _coordinates = default;
        private readonly CellDisplay _cellDisplay = default;

        public Cell(Vector2Int coordinates, CellDisplay cellDisplay)
        {
            _coordinates = coordinates;
            _cellDisplay = cellDisplay;
        }
    }
}