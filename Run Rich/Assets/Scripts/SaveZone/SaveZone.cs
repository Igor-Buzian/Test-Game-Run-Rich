using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class SaveZone : MonoBehaviour
{
    LoseLogic winLoseLogic;
    [SerializeField] private Animator flag1; // Ïונגûי פכאד
    [SerializeField] private Animator flag2; // Âעמנמי פכאד
    private void Start()
    {
        winLoseLogic = FindAnyObjectByType<LoseLogic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winLoseLogic.Position = transform.position;
            flag1.enabled = true;
            flag2.enabled = true;
        }
    }

  
}