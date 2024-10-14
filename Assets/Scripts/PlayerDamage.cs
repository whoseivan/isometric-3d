using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Dictionary<string, int> damageByTag = new Dictionary<string, int>();
    public float damageTimeout = 0.2f;
    PlayerHP _playerHP;

    private float _lastDamageTime = 0f; // Время последнего получения урона

    private void Start()
    {
        _playerHP = GetComponent<PlayerHP>();

        damageByTag.Add("Enemy", 10);      // Тег "Enemy" наносит 10 урона
        damageByTag.Add("Trap", 20);       // Тег "Trap" наносит 20 урона
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerHP.getDamage(GetDamageByTag(other.gameObject.tag));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Проверяем, прошло ли достаточно времени с момента последнего получения урона
        if (Time.time >= _lastDamageTime + damageTimeout)
        {
            int damage = GetDamageByTag(hit.gameObject.tag);
            if (damage > 0)
            {
                _playerHP.getDamage(damage);
                _lastDamageTime = Time.time; // Обновляем время последнего получения урона
            }
        }
    }

    public int GetDamageByTag(string tag)
    {
        if (damageByTag.ContainsKey(tag))
        {
            return damageByTag[tag]; // Если тег найден, возвращаем урон
        }
        return 0; // Если тег не найден, урон равен 0
    }
}
