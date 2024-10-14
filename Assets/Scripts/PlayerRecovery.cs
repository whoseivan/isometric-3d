using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecovery : MonoBehaviour
{
    public Dictionary<string, int> recoveryByTag = new Dictionary<string, int>();
    PlayerHP _playerHP;

    private void Start()
    {
        _playerHP = GetComponent<PlayerHP>();

        recoveryByTag.Add("SmallMedkit", 10);      // ��� "Enemy" ������� 10 �����
        recoveryByTag.Add("MediumMedkit", 25);       // ��� "Trap" ������� 20 �����
        recoveryByTag.Add("BigMedkit", 50);       // ��� "Trap" ������� 20 �����
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerHP.getRecovery(GetRecoveryByTag(other.gameObject.tag, other.gameObject));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    { 
        _playerHP.getRecovery(GetRecoveryByTag(hit.gameObject.tag, hit.gameObject)); 
    }

    public int GetRecoveryByTag(string tag, GameObject obj)
    {
        if (recoveryByTag.ContainsKey(tag))
        {
            Destroy(obj);
            return recoveryByTag[tag]; // ���� ��� ������, ���������� ����
        }
        return 0; // ���� ��� �� ������, ���� ����� 0
    }
}
