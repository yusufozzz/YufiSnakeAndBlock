using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace SnakeVsBlock.Scripts.Ui
{
    public class JoystickPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public float TouchDelta { get; private set; }

        public Action OnDragEnd;
        
        private Vector3 _beginPos;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _beginPos = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            TouchDelta = (eventData.position.x - _beginPos.x) / Screen.width;
            TouchDelta = Mathf.Clamp(TouchDelta, -1, 1);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            TouchDelta = 0;
            OnDragEnd?.Invoke();
        }
    }
}