using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб кулі
    public Transform bulletSpawnPoint; // Точка, з якої буде починатися політ кулі
    public AudioClip bulletSpawnSound;

    void Update()
    {
        AudioClip audioClip = GetComponent<AudioClip>();
        if (Input.GetMouseButtonDown(0)) // Перевіряємо, чи натиснута ліва кнопка мишки
        {
            Shooting(); // Викликаємо функцію пострілу
            AudioClip clip = bulletSpawnSound;
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Створюємо копію префабу кулі
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // Отримуємо посилання на компонент Rigidbody кулі

        // Застосовуємо силу до кулі, щоб запустити її уперед
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * 500f, ForceMode.Impulse);
    }
}
