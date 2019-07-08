using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Pooling : MonoBehaviour
{
   public GameObject ItemToPool;
   public List<GameObject> Pool;
   private int poolCount;
   private WaitForSecondsObj wfsObj;
   public float poolDelay = 0.125f;
   
   public void AddToPool(int numberToAdd)
   {
      for (var i = 0; i < numberToAdd; i++)
      {
         var item = Instantiate(ItemToPool);
         Pool.Add(item);
      }
   }

   private void Start()
   {
      wfsObj = ScriptableObject.CreateInstance<WaitForSecondsObj>();
      wfsObj.Seconds = poolDelay;
      wfsObj.Create();
   }

   public void DisableAllPoolItems()
   {
      foreach (var item in Pool)
      {
         item.SetActive(false);
      }
   }

   public void UsePool()
   {
      if (poolCount < Pool.Count)
      {
         Pool[poolCount].SetActive(true);
         poolCount++;
      }
      else
      {
         poolCount = 0;
         Pool[poolCount].SetActive(true);
      }
   }

   public void UsePoolRapidly()
   {
      StartCoroutine(UsePoolCoroutine());
   }
   
   private IEnumerator UsePoolCoroutine()
   {
      var i = 0;
      while (i < Pool.Count)
      {
         Pool[i].SetActive(true);
         yield return new WaitForSeconds(poolDelay);
         i++;
      }
   }
}