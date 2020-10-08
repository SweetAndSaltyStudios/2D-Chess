using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class PieceDisplay : EventTrigger
    {
        public Image Image { get => GetComponent<Image>(); }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
        }
        public override void OnDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);

            transform.position += (Vector3)eventData.delta;
        }
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
        }
    }
}