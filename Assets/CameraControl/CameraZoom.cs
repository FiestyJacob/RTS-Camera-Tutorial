using UnityEngine;

namespace CameraControl {
	public class CameraZoom : MonoBehaviour{
		[SerializeField] private Transform _cameraHolder;
		[SerializeField] private float _smoothing = 5f;
		[SerializeField] private float _speed = 25f;
		[SerializeField] private Vector2 _range = new (30f, 70f);
	
		private float _input;
		private Vector3 _targetPosition;
		
		private Vector3 _cameraDirection => transform.InverseTransformDirection(_cameraHolder.forward);
		
		private void Awake() {
			_targetPosition = _cameraHolder.localPosition;
		}

		private void HandleInput() {
			_input = Input.GetAxisRaw("Mouse ScrollWheel");
		}

		private void Zoom() {
			_targetPosition += _cameraDirection * (_input * _speed);
			
			if (_targetPosition.magnitude < _range.x) _targetPosition = -_cameraDirection * _range.x;
			if (_targetPosition.magnitude > _range.y) _targetPosition = -_cameraDirection * _range.y;
			
			_cameraHolder.localPosition = Vector3.Lerp(_cameraHolder.localPosition, _targetPosition, Time.deltaTime * _smoothing);
		}
		
		private void Update() {
			HandleInput();
			Zoom();
		}
	}
}