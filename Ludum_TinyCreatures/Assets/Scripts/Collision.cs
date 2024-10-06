using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep")) 
        {
            Destroy(other.gameObject);
            GameManager.Instance.CountSheep++;
        }

        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.KeyCount++;
        }

        if (other.CompareTag("SecretKey"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.KeySecretDoorCount++;
        }
    }
}
