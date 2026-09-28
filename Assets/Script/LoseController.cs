using UnityEngine;

public class LoseController : MonoBehaviour
{
    private bool isTriggered = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerTrap();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTrap();
        }
    }
    void TriggerTrap()
    {
       
        if (isTriggered) return;
        isTriggered = true;

        Debug.Log("Đã chạm vào vật thể độc! Phát âm thanh thua.");

        // Phát âm thanh thua thông qua AudioManager
        if (AudioManager.Instance != null)
        {
            
            // Gọi âm thanh thua
            AudioManager.Instance.PlayLoseSound();
        }
    }
}
