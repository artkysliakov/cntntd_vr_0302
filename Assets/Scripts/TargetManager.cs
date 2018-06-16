using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [Header("Bouncy Target")]
    public int maxBouncyTargetsCount = 2;
    private int currentBouncyTargetsCount = 0;
    public Transform bouncyRespawnPoint;
    public GameObject bouncyTargetPrefab;

    [Header("Heavy Target")]
    public int maxHeavyTargetsCount = 2;
    private int currentHeavyTargetsCount = 0;
    public Transform heavyRespawnPoint;
    public GameObject heavyTargetPrefab;

    [Header("Cilinder Target")]
    public int maxCilinderTargetsCount = 2;
    private int currentCilinderTargetsCount = 0;
    public Transform cilinderRespawnPoint;
    public GameObject cilinderTargetPrefab;

    public void InstantiateBouncyTarget()
    {
        if(currentBouncyTargetsCount < maxBouncyTargetsCount)
        {
            Instantiate(bouncyTargetPrefab, bouncyRespawnPoint.position, bouncyRespawnPoint.rotation);
            currentBouncyTargetsCount++;
        }
    }

    public void InstantiateHeavyTarget()
    {
        if (currentHeavyTargetsCount < maxHeavyTargetsCount)
        {
            Instantiate(heavyTargetPrefab, heavyRespawnPoint.position, heavyRespawnPoint.rotation);
            currentHeavyTargetsCount++;
        }
    }

    public void InstantiateCilinderTarget()
    {
        if (currentCilinderTargetsCount < maxCilinderTargetsCount)
        {
            Instantiate(cilinderTargetPrefab, cilinderRespawnPoint.position, cilinderRespawnPoint.rotation);
            currentCilinderTargetsCount++;
        }
    }
}
