using UnityEngine;

public class DestroyOnTop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
        }
    }
}
