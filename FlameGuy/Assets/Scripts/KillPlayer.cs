using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player into Killzone");
            //other.gameObject.GetComponent<CharacterController>().Move(Vector3.up - other.transform.position);
            LevelManager.instance.ReSpawn();
            
        }
    }

    
}
