using UnityEngine;

public class ThefalloftheBall : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.forward;
    }

    //_speed - это скорость нашего движение вперед. transform.position - это положение нажего обЪекта. 
    //Vector3.forward - это означает направление движения вперед.
}
