using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Player Controller/Isometric Character with Jump")]

public class IsometricCharacter : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5.0f;            // Скорость передвижения
    public float gravity = -9.81f;        // Сила гравитации
    public float jumpHeight = 2.0f;       // Высота прыжка

    [Header("Camera Settings")]
    public Transform cameraTransform;      // Ссылка на камеру

    private CharacterController _charController;
    private Vector3 _velocity;             // Текущая скорость персонажа
    private bool _isGrounded;              // Флаг, находится ли персонаж на земле

    void Start()
    {
        // Получаем компонент CharacterController
        _charController = GetComponent<CharacterController>();

        // Если ссылка на камеру не задана, используем основную камеру
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Проверка, находится ли персонаж на земле
        _isGrounded = _charController.isGrounded;
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Небольшая отрицательная скорость для стабильности
        }

        // Получение ввода от игрока
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Преобразуем вектор движения с учетом направления камеры
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Убираем влияние вертикали камеры
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Рассчитываем конечный вектор движения
        Vector3 move = (right * inputX + forward * inputZ).normalized;

        // Применение скорости передвижения
        Vector3 movement = move * speed;

        // Применение гравитации
        _velocity.y += gravity * Time.deltaTime;

        // Обработка прыжка
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Добавляем вертикальную скорость к движению
        movement += _velocity;

        // Преобразуем локальные координаты в глобальные и применяем перемещение
        _charController.Move(movement * Time.deltaTime);
    }
}
