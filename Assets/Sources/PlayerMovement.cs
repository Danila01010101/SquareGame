using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _cursorFollowTime;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Camera _mainCamera;

    private Vector3 _newPosition;
    private bool _isControlledByMouse = false;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        RaycastHit hit;
        Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.GetComponent<PlayerMovement>())
            {
                _isControlledByMouse = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isControlledByMouse = false;
        }

        TryMove(hit);
    }

    private void TryMove(RaycastHit hit)
    {
        if (_isControlledByMouse)
        {
            _newPosition.x = hit.point.x;
            _newPosition.y = _playerTransform.position.y;
            _newPosition.z = hit.point.z;

            _playerTransform.DOMove(_newPosition, _cursorFollowTime).SetLoops(1);
        }
    }
}
