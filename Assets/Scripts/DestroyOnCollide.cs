using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
        }
    }
}
