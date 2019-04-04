using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoredEnergy))]
public class Generator : MonoBehaviour {
    
    StoredEnergy energyComponent;

    private void Start()
    {
        energyComponent = GetComponent<StoredEnergy>();
    }

    private void OnMouseDown()
    {
        if (energyComponent.currentEnergy > 0 && energyComponent.canShootAgain)
        {
            GameObject energy = (GameObject)Instantiate(Resources.Load("Energy"), transform.position, transform.rotation);
            energy.GetComponent<Energy>().SetEnergy(energyComponent.energyToReduce, energyComponent.GetColor(), gameObject);
        }
        energyComponent.ReduceEnergy();
    }
}
