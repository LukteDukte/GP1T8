using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rotifer : MonoBehaviour
{
    public Animator rotiferAnimator;

    public Transform mouth;

    private bool hasEaten = false; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name + " is about to be eaten");
        if (other.CompareTag("Volvox") && !hasEaten)
        {
            Volvox volvox = other.GetComponent<Volvox>();
            Debug.Log(volvox);

            GameObject latestColony = volvox.GetLatestColony();
            if (latestColony)
            {
                latestColony.transform.SetParent(mouth);
                latestColony.transform.localPosition = Vector3.zero;
                VolvoxSize.instance.UpdateSize();
                Debug.Log("1 colony is eaten by rotifer");
            }

            hasEaten = true;
        }
    }


    public void ClearMouth()
    {
        hasEaten = false;
        int count = mouth.childCount;
        print("Count: "+count);
        for (int i = 0; i < count; i++)
        {
            GameObject obj = mouth.GetChild(i).gameObject;
            Destroy(obj);
        }
    }
}