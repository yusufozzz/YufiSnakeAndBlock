using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake.Segment
{
    [CreateAssetMenu(fileName = "SegmentDataSo", menuName = "SnakeVsBlock/SegmentDataSo", order = 0)]
    public class SegmentDataSo : ScriptableObject
    {
        [field: SerializeField]
        public float ArriveDistance { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}