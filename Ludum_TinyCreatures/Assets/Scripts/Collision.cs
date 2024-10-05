using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Sheep"))
            return;
        
        Destroy(other.gameObject);
        
        GameManager.Instance.CountSheep++;
    }
}
