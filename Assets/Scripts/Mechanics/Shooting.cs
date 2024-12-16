using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;  // Точка стрельбы
    public GameObject bulletPrefab;  // Префаб пули
    public float bulletSpeed = 20f;  // Скорость пули
    public AudioClip bulletSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Проверка ввода для стрельбы
        if (Input.GetButtonDown("Fire1"))  // Fire1 по умолчанию привязан к ЛКМ или Ctrl
        {
            // Создаем копию пули на позиции точки стрельбы и в том же направлении
            GameObject bulletCopy = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));

            // Проверяем, есть ли у пули компонент Rigidbody
            Rigidbody rb = bulletCopy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 position = transform.forward;
                    position.y = 0f;
                    rb.velocity =  position * bulletSpeed;

                audioSource.PlayOneShot(bulletSound);

            }
        }
    }
}
