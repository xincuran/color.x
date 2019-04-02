using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoredEnergy))]
public class Collector : MonoBehaviour {
    
    float collectedEnergy;

    StoredEnergy energyComponent;

    private void Start()
    {
        energyComponent = GetComponent<StoredEnergy>();
    }

    private void Update()
    {
        if (energyComponent.canShootAgain)
        {
            energyComponent.AddEnergy(collectedEnergy);
            collectedEnergy = 0;
        }
    }

    public void CollectEnergy (float energy)
    {
        collectedEnergy += energy;
    }

    public bool CheckFilled()
    {
        if (energyComponent.currentEnergy >= energyComponent.capacity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
