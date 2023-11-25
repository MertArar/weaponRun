using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenDoor"))
        {
            ModifyYear(100); // Yeşil kapıya çarparsa yılı artır
            Destroy(gameObject); // Mermiyi yok et
        }
        else if (other.CompareTag("RedDoor"))
        {
            ModifyYear(-100); // Kırmızı kapıya çarparsa yılı azalt
            Destroy(gameObject); // Mermiyi yok et
        }
    }

    void ModifyYear(int amount)
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.ModifyYear(amount);
        }
    }
}