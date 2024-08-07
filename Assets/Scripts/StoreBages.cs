using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBages : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
         PlayerInvrntary playerInvrntary= other.GetComponent<PlayerInvrntary>();

        if (playerInvrntary != null)
        {
            Debug.Log("Bag Collected");
            playerInvrntary.CollectBag();
            gameObject.SetActive(false);
        }
    }
   

}
