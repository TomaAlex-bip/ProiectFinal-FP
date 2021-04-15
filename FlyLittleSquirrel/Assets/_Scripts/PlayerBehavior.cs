using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    public bool next = false;
    public GameObject currentTerrain;
    public bool running = true;


    private void Start()
    {
        running = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("next"))
        {
            Debug.Log("trebuie sa se schimbe!");
            next = true;
        }

        if(other.transform.CompareTag("current"))
        {
            Debug.Log("am intrat");
            currentTerrain = other.transform.parent.gameObject;
            
        }

        if(other.transform.CompareTag("Respawn"))
        {
            Debug.Log("ai dat cu capu de piatra");
            running = false;

        }

    }

    
}
