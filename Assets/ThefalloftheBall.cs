using UnityEngine;

public class ThefalloftheBall : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.forward;
    }

    //_speed - ��� �������� ������ �������� ������. transform.position - ��� ��������� ������ �������. 
    //Vector3.forward - ��� �������� ����������� �������� ������.
}
