using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackPoint : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         LevelManager.instance.respawnPoint = transform.position;
      }
   }
}