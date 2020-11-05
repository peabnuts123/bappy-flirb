using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    // Public references
    [NotNull]
    [SerializeField]
    private Transform followTarget;

    // Private references
    [Inject]
    private new Camera camera;

    public void Update()
    {
        float cameraHalfWidthWorldSpace = this.camera.orthographicSize * this.camera.aspect;
        this.transform.position = this.transform.position.WithX(this.followTarget.position.x + (cameraHalfWidthWorldSpace * 0.6F));
    }
}