using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class MoveUnityEvent : UnityEvent<Vector3> { }
    public class PieceDisplay : MonoBehaviour,
    IPointerEnterHandler, 
    IEventSystemHandler, 
    IPointerExitHandler,
    IPointerDownHandler, 
    IPointerUpHandler, 
    IPointerClickHandler, 
    IBeginDragHandler, 
    IDragHandler, 
    IEndDragHandler
    {
        public UnityEvent OnPointerEnter_Event = new UnityEvent();
        public UnityEvent OnPointerDown_Event = new UnityEvent();
        public UnityEvent OnPointerClick_Event = new UnityEvent();
        public UnityEvent OnPointerUp_Event = new UnityEvent();
        public UnityEvent OnPointerExit_Event = new UnityEvent();
        public UnityEvent OnBeginDrag_Event = new UnityEvent();
        public UnityEvent<Vector3> OnDrag_Event = new MoveUnityEvent();
        public UnityEvent OnEndDrag_Event = new UnityEvent();

        public Image Image { get => GetComponent<Image>(); }

        private void Awake() => RegisterListeners();
        private void OnDestroy() => RemoveAllListeners();

        private void RegisterListeners()
        {
            OnDrag_Event.AddListener(Move);
            OnPointerDown_Event.AddListener(ShowPossibleMoves);
        }

        private void RemoveAllListeners()
        {
            OnPointerEnter_Event.RemoveAllListeners();
            OnPointerDown_Event.RemoveAllListeners();
            OnPointerClick_Event.RemoveAllListeners();
            OnPointerUp_Event.RemoveAllListeners();
            OnPointerExit_Event.RemoveAllListeners();
            OnBeginDrag_Event.RemoveAllListeners();
            OnDrag_Event.RemoveAllListeners();
            OnEndDrag_Event.RemoveAllListeners();
        }

        private void Move(Vector3 deltaPosition)
        {
            transform.position += deltaPosition;
        }
        private void ShowPossibleMoves()
        {
            Debug.Log("SHOW POSSIBLE MOVES");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnter_Event?.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDown_Event?.Invoke();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClick_Event?.Invoke();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUp_Event?.Invoke();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExit_Event?.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDrag_Event?.Invoke();
        }
        public void OnDrag(PointerEventData eventData)
        {
            OnDrag_Event?.Invoke(eventData.delta);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDrag_Event?.Invoke();
        }
    }
}