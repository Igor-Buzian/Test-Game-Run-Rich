using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private Animator flag1; // ������ ����
    [SerializeField] private Animator flag2; // ������ ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flag1.enabled = true;
            flag2.enabled = true;
        }
    }
}
