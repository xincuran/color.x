using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

    float energyAmount;

    GameObject author;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collector>() && other.gameObject != author)
        {
            if(other.GetComponent<Collector>().CheckFilled() == false)
            {
                other.GetComponent<Collector>().CollectEnergy(energyAmount);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 5f);
        //Remember to add proper direction code.
        //Create working color system.
    }

    public void SetEnergy (float energy, GameObject authority)
    {
        energyAmount = energy;
        author = authority;
    }
}
