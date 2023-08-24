using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake
{
    [CreateAssetMenu(fileName = "SnakeData", menuName = "SnakeVsBlock/SnakeData", order = 0)]
    public class SnakeData: ScriptableObject
    {
        [field: SerializeField]
        public float SnakeVerticalSpeed { get; private set; }

        [field: SerializeField]
        public float SnakeHorizontalSpeed { get; private set; }

        [field: SerializeField]
        public float RoadLimit { get; private set; }
    }
}