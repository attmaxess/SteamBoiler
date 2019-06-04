using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] ThirdPersonCamera tpCamera;
	Vector3 posOld;
	Vector3 eulerAnglesOld;
	enum TypeCamera {
		LOOK_DOWN,
		LOOK_HORIZONTAL
	}
	TypeCamera currentType;
	bool canDrag = true;
	public bool CanDrag {
		get { return canDrag; }
		set { canDrag = value; }
	}
	void Start () {
		currentType = TypeCamera.LOOK_HORIZONTAL;
		tpCamera.Pitch = 40;
	}
	public void SetCameraLookDown () {
		tpCamera.Pitch = 90;
	}

	public void SetCameraLookHorizontal () {
		tpCamera.Pitch = 0;
	}

	private void Update () {

		if (!canDrag) return;
#if UNITY_EDITOR
		if (Input.GetMouseButton (0)) {
			tpCamera.Yaw += Input.GetAxis ("Mouse X") * 10;
			tpCamera.Pitch -= Input.GetAxis ("Mouse Y") * 10;
		}

		tpCamera.Distance -= Input.GetAxis ("Mouse ScrollWheel") * 10;
#else
		CalculateTouchDrag ();
		CalculatePinchZoom ();
		const float ROTATING_SPEED = .2f;
		const float ZOOMING_SPEED = .07f;

		tpCamera.Yaw += HorizontalDrag * ROTATING_SPEED;
		tpCamera.Pitch += VerticalDrag * ROTATING_SPEED;
		tpCamera.Distance += PinchZoomValue * ZOOMING_SPEED;
#endif

	}
	public float PinchZoomValue { get; set; }

	public float HorizontalDrag { get; set; }
	public float VerticalDrag { get; set; }

	void CalculateTouchDrag () {

		HorizontalDrag = VerticalDrag = 0;

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

			// Move object across XY plane
			HorizontalDrag = touchDeltaPosition.x;
			VerticalDrag = -touchDeltaPosition.y;
		}
	}

	void CalculatePinchZoom () {

		PinchZoomValue = 0;

		// If there are two touches on the device...
		if (Input.touchCount == 2 &&
			(Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved)) {

			// Store both touches.
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			PinchZoomValue = deltaMagnitudeDiff;
		}
	}
}