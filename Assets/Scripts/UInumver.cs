using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UInumver : MonoBehaviour
{
    private TextMeshProUGUI Bagtext;
    void Start()
    {
       Bagtext= GetComponent<TextMeshProUGUI>(); 
    }

    public void UpdateBagText(PlayerInvrntary playerInvrntary)
    {
        Bagtext.text=playerInvrntary.Collectedbags.ToString();
    }
}
