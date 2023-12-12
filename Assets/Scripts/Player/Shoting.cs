using System.Collections;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _attackCoolDownTime;
    [SerializeField] private float _destroyBullet;
    private bool _isRecharged;

    private Rigidbody _rb;
    private GameObject _bullet;
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _isRecharged = true;
    }
    private void Update()
    {
        if (Input.GetButton("Fire1")) Shoot();
    }
    private void Shoot()
    {
        if (_isRecharged && _playerController.Controller.isGrounded)
        {
            _bullet = Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);
            _rb = _bullet.GetComponent<Rigidbody>();
            _rb.AddForce(_spawnBullet.forward * _bulletForce, ForceMode.Impulse);
            _isRecharged = false;

            StartCoroutine(AttackCoolDown());           
        }
        Destroy(_bullet, _destroyBullet);
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDownTime);
        _isRecharged = true;
    }
}
