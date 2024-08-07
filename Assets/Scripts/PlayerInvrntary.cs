using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInvrntary : MonoBehaviour
{
    public int Collectedbags { get; private set; }

    public UnityEvent<PlayerInvrntary> OnBagCollected;

    public void CollectBag()
    {
        Collectedbags++;
        OnBagCollected.Invoke(this);
    }
}
