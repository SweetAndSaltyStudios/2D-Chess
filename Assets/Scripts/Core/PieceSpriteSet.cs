using System;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    [Serializable]
    public class PieceSpriteSet
    {
        [SerializeField] private Sprite[] _whiteSprites = default;
        [SerializeField] private Sprite[] _blackSprites = default;

        public Sprite[] WhiteSprites { get => _whiteSprites; }
        public Sprite[] BlackSprites { get => _blackSprites; }
    }
}