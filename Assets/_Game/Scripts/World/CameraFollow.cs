using UnityEngine;

namespace Elysia.World
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3   offset      = new Vector3(0f, 5f, -7f);
        [SerializeField] float     smoothSpeed = 8f;

        void LateUpdate()
        {
            if (target == null) return;

            Vector3 desired = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
            transform.LookAt(target);
        }
    }
}
