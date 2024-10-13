using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Player Controller/Isometric Character with Jump")]

public class IsometricCharacter : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5.0f;            // �������� ������������
    public float gravity = -9.81f;        // ���� ����������
    public float jumpHeight = 2.0f;       // ������ ������

    [Header("Camera Settings")]
    public Transform cameraTransform;      // ������ �� ������

    private CharacterController _charController;
    private Vector3 _velocity;             // ������� �������� ���������
    private bool _isGrounded;              // ����, ��������� �� �������� �� �����

    void Start()
    {
        // �������� ��������� CharacterController
        _charController = GetComponent<CharacterController>();

        // ���� ������ �� ������ �� ������, ���������� �������� ������
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // ��������, ��������� �� �������� �� �����
        _isGrounded = _charController.isGrounded;
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // ��������� ������������� �������� ��� ������������
        }

        // ��������� ����� �� ������
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // ����������� ������ �������� � ������ ����������� ������
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ������� ������� ��������� ������
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // ������������ �������� ������ ��������
        Vector3 move = (right * inputX + forward * inputZ).normalized;

        // ���������� �������� ������������
        Vector3 movement = move * speed;

        // ���������� ����������
        _velocity.y += gravity * Time.deltaTime;

        // ��������� ������
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ��������� ������������ �������� � ��������
        movement += _velocity;

        // ����������� ��������� ���������� � ���������� � ��������� �����������
        _charController.Move(movement * Time.deltaTime);
    }
}