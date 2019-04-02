using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoredEnergy : MonoBehaviour {

    public float capacity;
    public float currentEnergy;
    public float energyToReduce;

    Image fillImage;

    public bool canShootAgain;

    private void Awake()
    {
        fillImage = GetComponent<Image>();

        canShootAgain = true;
    }

    public void AddEnergy (float energy)
    {
        if(currentEnergy < capacity)
        {
            currentEnergy += energy;
            StartCoroutine(AddEnergySmooth());
        }
    }

    public void ReduceEnergy()
    {
        if(currentEnergy > 0 && canShootAgain)
        {
            currentEnergy -= energyToReduce;
            StartCoroutine(ReduceEnergySmooth());
        }
    }

    IEnumerator ReduceEnergySmooth ()
    {
        canShootAgain = false;
        while(fillImage.fillAmount > (currentEnergy / capacity))
        {
            fillImage.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.0000001f);
        }
        canShootAgain = true;
    }

    IEnumerator AddEnergySmooth()
    {
        canShootAgain = false;
        while (fillImage.fillAmount < (currentEnergy / capacity))
        {
            fillImage.fillAmount += 0.01f;
            yield return new WaitForSeconds(0.0000001f);
        }
        canShootAgain = true;
    }
}
