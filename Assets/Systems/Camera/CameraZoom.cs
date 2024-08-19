using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameBalanceAttributes attributes;
    public CinemachineVirtualCamera virtualCamera;
    public float minDistance;
    public float maxDistance;

    private float proportion;

    private void OnEnable()
    {
        LevelManager.Instance.TotemPlaced += SpeedCameraChange;
    }

    private void OnDisable()
    {
        LevelManager.Instance.TotemPlaced -= SpeedCameraChange;
    }

    private void SpeedCameraChange()
    {
        float attributeDiff = attributes.totalSpeed - attributes.playerBaseMovementSpeed;
        proportion = Mathf.Clamp01(attributeDiff / 20);

        float cameraDistance = Mathf.Lerp(minDistance, maxDistance, proportion);

        CinemachineComponentBase componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = cameraDistance;
        }
    }
}
