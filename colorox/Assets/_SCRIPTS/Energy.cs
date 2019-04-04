using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

    float energyAmount;
    string energyColor;

    GameObject author;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collector>() && other.gameObject != author)
        {
            if(other.GetComponent<Collector>().CheckFilled() == false)
            {
                other.GetComponent<Collector>().CollectEnergy(energyAmount, energyColor);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 5f);
        //Remember to add proper direction code.
        //Create Color match system.
        //Record the ac ca bug.
    }

    public void SetEnergy (float energy, string _color, GameObject authority)
    {
        energyAmount = energy;
        energyColor = _color;
        author = authority;
    }
}
