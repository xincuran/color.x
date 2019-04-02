using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoredEnergy))]
public class Generator : MonoBehaviour {

    public Energy energyPrefab;

    StoredEnergy energyComponent;

    private void Start()
    {
        energyComponent = GetComponent<StoredEnergy>();
    }

    private void OnMouseDown()
    {
        if (energyComponent.currentEnergy > 0 && energyComponent.canShootAgain)
        {
            GameObject energy = Instantiate(energyPrefab.gameObject, transform.position, transform.rotation);
            energy.GetComponent<Energy>().SetEnergy(energyComponent.energyToReduce, gameObject);
        }
        energyComponent.ReduceEnergy();
    }
}
