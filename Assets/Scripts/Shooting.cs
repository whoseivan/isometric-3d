using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;  // Точка стрельбы
    public GameObject bulletPrefab;  // Префаб пули
    public float bulletSpeed = 20f;  // Скорость пули

    void Update()
    {
        // Проверка ввода для стрельбы
        if (Input.GetButtonDown("Fire1"))  // Fire1 по умолчанию привязан к ЛКМ или Ctrl
        {
            // Создаем копию пули на позиции точки стрельбы и в том же направлении
            GameObject bulletCopy = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

            // Проверяем, есть ли у пули компонент Rigidbody
            Rigidbody rb = bulletCopy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Применяем силу для перемещения пули в направлении вперед относительно точки стрельбы (оси X)
                rb.velocity = shootingPoint.forward * bulletSpeed;
            }
        }
    }
}
