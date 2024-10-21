using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitBeforeRespawning;
    public bool respawning;
    private PlayerController player;
    public Vector3 respawnPoint;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        respawnPoint = player.transform.position;
        UIController.instance.FadeFromBlack();
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
        player.gameObject.SetActive(false);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds(waitBeforeRespawning);
        player.transform.position = respawnPoint;
        player.gameObject.SetActive(true);
        UIController.instance.FadeFromBlack();
        respawning = false;
    }
}
