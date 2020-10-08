using System;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class ResourceManager : MonoBehaviour
    {
        [Space]
        [Header("Prefabs")]
        [SerializeField] private BoardDisplay _boardDisplayPrefab = default;
        [SerializeField] private CellDisplay _cellDisplayPrefab = default;
        [SerializeField] private PieceDisplay _pieceDisplayPrefab = default;
        [SerializeField] private PlayerDisplay _playerDisplayPrefab = default;

        [Space]
        [Header("Piece Sprite Sets")]
        [SerializeField] private PieceSpriteSet _pieceSpriteSets = default;

        [Space]
        [Header("Cell Sprites")]
        [SerializeField] private Sprite _whiteCell = default;
        [SerializeField] private Sprite _blackCell = default;

        private MonoBehaviour[] _allPrefabs = default;

        public static ResourceManager Instance { get; private set; }
       
        public Sprite WhiteCell { get => _whiteCell; }
        public Sprite BlackCell { get => _blackCell; }

        private void Awake() => Initialize();

        public Sprite GetSpriteByType(Type pieceType, COLOR_TYPE colorType)
        {
            // TODO: ...
            if(pieceType == typeof(Pawn)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[0] : _pieceSpriteSets.BlackSprites[0];
            if(pieceType == typeof(Rook)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[1] : _pieceSpriteSets.BlackSprites[1];
            if(pieceType == typeof(Knight)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[2] : _pieceSpriteSets.BlackSprites[2];
            if(pieceType == typeof(Bishop)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[3] : _pieceSpriteSets.BlackSprites[3];
            if(pieceType == typeof(Queen)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[4] : _pieceSpriteSets.BlackSprites[4];
            if(pieceType == typeof(King)) return colorType == COLOR_TYPE.WHITE ? _pieceSpriteSets.WhiteSprites[5] : _pieceSpriteSets.BlackSprites[5];

            return null;
        }

        private void Initialize()
        {
            if(Instance == null) Instance = this;
            else Destroy(gameObject);

            _allPrefabs = new MonoBehaviour[]
            {
                _boardDisplayPrefab,
                _cellDisplayPrefab,
                _pieceDisplayPrefab,
                _playerDisplayPrefab
            };
        }
        public T SpawnInstance<T>(string name = default, Transform parent = default, Vector2 position = default, Quaternion rotation = default) where T : MonoBehaviour
        {
            var instance = Instantiate(GetPrefabFromType<T>(), position, rotation, parent);
            instance.name = name;

            return instance;
        }
        private T GetPrefabFromType<T>() where T : MonoBehaviour
        {
            var type = typeof(T);

            foreach(var prefab in _allPrefabs)
            {
                if(prefab.GetType() != type) continue;

                return prefab as T;
            }

            return default;
        }
    }
}