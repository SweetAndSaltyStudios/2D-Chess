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
        [Header("Sprites")]
        [SerializeField] private Sprite _whiteCell = default;
        [SerializeField] private Sprite _blackCell = default;

        private MonoBehaviour[] _allPrefabs = default;

        public static ResourceManager Instance { get; private set; }
       
        public Sprite WhiteCell { get => _whiteCell; }
        public Sprite BlackCell { get => _blackCell; }

        private void Awake() => Initialize();

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