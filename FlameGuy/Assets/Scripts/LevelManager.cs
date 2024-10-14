using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitBeforeRespawning;
    public bool respawning;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ReSpawn()
    {
        if (!respawning)
        {
            respawning = true;
            StartCoroutine(ReSpawnCo());
        }
    }

    IEnumerator ReSpawnCo()
    {
        yield return new WaitForSeconds(waitBeforeRespawning);
    }
}
