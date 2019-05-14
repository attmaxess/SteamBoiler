using UnityEngine;

namespace Lean.Touch
{	
	public class LeanTranslateToRotateX : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreStartedOverGui = true;

		[Tooltip("Ignore fingers with IsOverGui?")]
		public bool IgnoreIsOverGui;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("The camera the translation will be calculated using (None = MainCamera)")]
		public Camera Camera;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

		protected virtual void Update()
		{
			// Get the fingers we want to use
			var fingers = LeanSelectable.GetFingers(IgnoreStartedOverGui, IgnoreIsOverGui, RequiredFingerCount, RequiredSelectable);

			// Calculate the screenDelta value based on these fingers
			var screenDelta = LeanGesture.GetScreenDelta(fingers);

			if (screenDelta != Vector2.zero)
			{
                // Perform the translation
                var twistDegrees = -screenDelta.x;

                if (transform is RectTransform)
				{
					TranslateToRotateUI(screenDelta);
				}
				else
				{
					TranslateToRotate(twistDegrees);
				}
			}
		}

		protected virtual void TranslateToRotateUI(Vector2 screenDelta)
		{
			// Screen position of the transform
			var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera, transform.position);

			// Add the deltaPosition
			screenPoint += screenDelta;

			// Convert back to world space
			var worldPoint = default(Vector3);

			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.parent as RectTransform, screenPoint, Camera, out worldPoint) == true)
			{
				transform.position = worldPoint;
			}
		}

		protected virtual void TranslateToRotate(float twistDegrees)
		{
            // Make sure the camera exists
            var camera = LeanTouch.GetCamera(Camera, gameObject);

            if (camera != null)
            {
                var axis = transform.InverseTransformDirection(camera.transform.up);
                transform.rotation *= Quaternion.AngleAxis(twistDegrees, axis);
            }
		}
	}
}