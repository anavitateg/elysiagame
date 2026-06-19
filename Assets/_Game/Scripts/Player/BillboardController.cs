using UnityEngine;

namespace Elysia.Player
{
    public class BillboardController : MonoBehaviour
    {
        Transform cameraTransform;

        void Awake()
        {
            cameraTransform = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.rotation = cameraTransform.rotation;
        }
    }
}
