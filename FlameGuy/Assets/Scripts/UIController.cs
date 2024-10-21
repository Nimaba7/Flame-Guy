using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public static UIController instance;
   public Image fadeScreen;
   public bool isFadeingToBlack, isFadeingFromBlack;
   public float fadeSpeed = 2.0f;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   void Update()
   {
      if (isFadeingToBlack)
      {
         fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
            Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed* Time.deltaTime)
         );
      }

      if (isFadeingFromBlack)
      {
         fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
            Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime)
         );
      }
   }

   public void FadeToBlack()
   {
      isFadeingToBlack = true;
      isFadeingFromBlack = false;
   }

   public void FadeFromBlack()
   {
      isFadeingToBlack = false;
      isFadeingFromBlack = true;
   }
}
