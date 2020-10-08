using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class PlayerDisplay : MonoBehaviour
    {
        private void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}