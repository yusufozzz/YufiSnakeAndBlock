using UnityEngine;

namespace SnakeVsBlock.Scripts.Snake.Segment
{
    public class Segment: MonoBehaviour
    {
        public void Move(Vector3 current, Vector3 target, float distance)
        {
            float ratio = distance / Vector3.Distance(current, target);
            transform.position = Vector3.Lerp(current, target, ratio);
        }
        
        public void Rotate(Vector3 target)
        {
            var directionToTarget = target - transform.position;
            var targetRotation = Quaternion.LookRotation(directionToTarget);
            targetRotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = targetRotation;
        }
    }
}