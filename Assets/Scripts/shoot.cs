using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ���
    public Transform bulletSpawnPoint; // �����, � ��� ���� ���������� ���� ���
    public AudioClip bulletSpawnSound;

    void Update()
    {
        AudioClip audioClip = GetComponent<AudioClip>();
        if (Input.GetMouseButtonDown(0)) // ����������, �� ��������� ��� ������ �����
        {
            Shooting(); // ��������� ������� �������
            AudioClip clip = bulletSpawnSound;
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // ��������� ���� ������� ���
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // �������� ��������� �� ��������� Rigidbody ���

        // ����������� ���� �� ���, ��� ��������� �� ������
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * 500f, ForceMode.Impulse);
    }
}
