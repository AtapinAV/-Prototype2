using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    private float _smoothVelocity;
    [SerializeField] private Transform _firstCamera;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _speedForce;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _firstCamera.eulerAngles.y;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref _smoothVelocity, _smoothTime);
            Vector3 move = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angel, 0f);
            _characterController.Move(_speedForce * Time.deltaTime * move.normalized);
        }
    }
}
