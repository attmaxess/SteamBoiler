using System.Collections;
using UnityEngine;

[AddComponentMenu("Camera/ThirdPersonCamera")]
[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField] Transform target;
    public Transform Target {
        get { return target; }
        set { target = value; }
    }

    [SerializeField] float smoothing = 8;

    [SerializeField] float lowerPitchLimit = -40;
    [SerializeField] float upperPitchLimit = 80f;
    [SerializeField] float minDistance = 1f;
    [SerializeField] float maxDistance = 5f;

    Camera _camera;

    [Header("Default values")]
    [SerializeField]
    float defaultYaw = 200;
    [SerializeField] float defaultPitch = 5;
    [SerializeField] float defaultDistance = 0;
    [SerializeField] bool resetWhenActive = true;

    public float Yaw { get; set; }
    public float Pitch { get; set; }
    public float Distance { get; set; }

    float yaw, pitch, distance;
    public Camera Camera {
        get {
            if (!_camera)
                _camera = GetComponent<Camera>();
            return _camera;
        }
    }

    private void OnEnable() {
        if (resetWhenActive)
            ResetToDefault();
    }

    public void ResetToDefault() {

        if (defaultYaw >= 0)
            yaw = Yaw = defaultYaw;

        if (defaultPitch >= 0)
            pitch = Pitch = defaultPitch;

        if (defaultDistance >= 0) {
            if (defaultDistance == 0)
                defaultDistance = minDistance + (maxDistance - minDistance) / 4;
            distance = Distance = defaultDistance;
        }

        LateUpdate();
    }

    void LateUpdate() {
        if (target) {

            // Clamping
            Pitch = ClampAngle(Pitch, lowerPitchLimit, upperPitchLimit);
            Distance = Mathf.Clamp(Distance, minDistance, maxDistance);

            if (smoothing > 0) {
                yaw = Mathf.Lerp(yaw, Yaw, Time.deltaTime * smoothing);
                pitch = Mathf.Lerp(pitch, Pitch, Time.deltaTime * smoothing);
                distance = Mathf.Lerp(distance, Distance, Time.deltaTime * smoothing);
            } else {
                yaw = Yaw;
                pitch = Pitch;
                distance = Distance;
            }

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 negDistance = Vector3.back * distance;
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}