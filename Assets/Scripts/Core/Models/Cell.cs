using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Cell
    {
        public Vector2Int Coordinates { get; } = default;
        public CellDisplay CellDisplay { get; } = default;
        public bool IsOccupied { get; private set; }

        public Cell(Vector2Int coordinates, CellDisplay cellDisplay)
        {
            Coordinates = coordinates;
            CellDisplay = cellDisplay;
        }
    }
}