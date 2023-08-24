using UnityEngine;
 
public class ForceCameraFollowOnlyZ : MonoBehaviour
{
	[SerializeField]
	private Transform followTarget;

	private void LateUpdate()
	{
		var transform1 = transform;
		var position = transform1.position;
		position.z = followTarget.position.z;
		transform1.position = position;
	}
}
