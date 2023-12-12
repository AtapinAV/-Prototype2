using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Destroy(collision.gameObject);
    }
}
