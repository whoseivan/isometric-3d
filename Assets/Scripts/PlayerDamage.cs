using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Dictionary<string, int> damageByTag = new Dictionary<string, int>();
    public float damageTimeout = 0.2f;
    PlayerHP _playerHP;

    private float _lastDamageTime = 0f; // ����� ���������� ��������� �����

    private void Start()
    {
        _playerHP = GetComponent<PlayerHP>();

        damageByTag.Add("Enemy", 10);      // ��� "Enemy" ������� 10 �����
        damageByTag.Add("Trap", 20);       // ��� "Trap" ������� 20 �����
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerHP.getDamage(GetDamageByTag(other.gameObject.tag));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // ���������, ������ �� ���������� ������� � ������� ���������� ��������� �����
        if (Time.time >= _lastDamageTime + damageTimeout)
        {
            int damage = GetDamageByTag(hit.gameObject.tag);
            if (damage > 0)
            {
                _playerHP.getDamage(damage);
                _lastDamageTime = Time.time; // ��������� ����� ���������� ��������� �����
            }
        }
    }

    public int GetDamageByTag(string tag)
    {
        if (damageByTag.ContainsKey(tag))
        {
            return damageByTag[tag]; // ���� ��� ������, ���������� ����
        }
        return 0; // ���� ��� �� ������, ���� ����� 0
    }
}
