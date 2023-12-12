using System.Collections;
using UnityEngine;

public class Endurance : MonoBehaviour
{
    [SerializeField] private int _hpPlayer;
    [SerializeField] private GameObject _pause;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Shoting _shoting;
    private void Update()
    {
        Die();
    }
    private void Die()
    {
        if (_hpPlayer <= 0)
        {
            _playerController.Animatorr.SetTrigger("Die");
            _playerController.enabled = false;
            _shoting.enabled = false;
            StartCoroutine(DieStopTime());
        }
    }
    private IEnumerator DieStopTime()
    {
        yield return new WaitForSeconds(3f);
        DieRestartLevel();
    }
    private void DieRestartLevel()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
    }
}
