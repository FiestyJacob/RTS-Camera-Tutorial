using UnityEngine;

namespace CameraControl {
	public class CameraMotion : MonoBehaviour {
		[SerializeField] private float _speed = 1f;
		[SerializeField] private float _smoothing = 5f;
		
		private Vector3 _input;
		private Vector3 _targetPosition;

		private void Awake() {
			_targetPosition = transform.position;
		}
			
		private void HandleInput() {
			float x = Input.GetAxisRaw("Horizontal");
			float z = Input.GetAxisRaw("Vertical");

			Vector3 right = transform.right * x;
			Vector3 forward = transform.forward * z;

			_input = (forward + right).normalized;
		}

		private void Move() {
			_targetPosition += _input * _speed;
			transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _smoothing);
		}

		private void Update() {
			HandleInput();
			Move();
		}
	}
}