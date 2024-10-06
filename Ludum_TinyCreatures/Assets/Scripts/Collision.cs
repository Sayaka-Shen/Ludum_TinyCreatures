using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep")) 
        {
            Destroy(other.gameObject);
            GameManager.Instance.CountSheep++;
            AudioManager.Instance.PlaySound(SoundClip.Sheep, Sources.Level);
        }

        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.KeyCount++;
            AudioManager.Instance.PlaySound(SoundClip.Key, Sources.Level);
        }

        if (other.CompareTag("SecretKey"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.KeySecretDoorCount++;
            AudioManager.Instance.PlaySound(SoundClip.Key, Sources.Level);
        }
    }
}
