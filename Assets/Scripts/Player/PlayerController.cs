using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    private float _smoothVelocity;
    private float _speedForce;
    private float _velocity;
    private float _gravityMove = -9.81f;
    [SerializeField] private float _jump;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {   
        _speedForce = _walkSpeed;
    }
    private void Update()
    {
        MovePlayer();
        Gravity();
        Jump();
        RunPlayer();
        JumpAnim();
    }
    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref _smoothVelocity, _smoothTime);
            Vector3 move = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angel, 0f);
            _characterController.Move(_speedForce * Time.deltaTime * move.normalized);
        }

        if (direction.magnitude >= 0.1f) _animator.SetBool("Walk", true);
        else { _animator.SetBool("Walk", false); }
    }
    private void Gravity()
    {
        if (!_characterController.isGrounded) _velocity += _gravityMove * Time.deltaTime;

        _characterController.Move(new Vector3(0f, _velocity, 0f) * Time.deltaTime);
    }
    private void Jump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) _velocity = _jump;
    }
    private void JumpAnim()
    {
        if (!_characterController.isGrounded) _animator.SetBool("Jump", true);
        else { _animator.SetBool("Jump", false); }
    }
    private void RunPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("Run", true);
            _speedForce = _runSpeed;
        }
        else
        {
            _animator.SetBool("Run", false);
            _speedForce = _walkSpeed;
        }
    }
}
