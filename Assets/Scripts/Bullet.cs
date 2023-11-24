using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f; // Mermi ömrü (saniye cinsinden)

    private void Start()
    {
        // Belirtilen süre sonunda mermiyi yok et
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Mermi başka bir nesneyle temas ettiğinde
        // Burada gerekirse çarpışma işlemleri veya başka eylemler yapılabilir.
        // Örnek olarak:
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Çarptığı şey bir düşman ise düşmanı yok et
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}