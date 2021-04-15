using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private GameObject currentTerrain;
    [SerializeField] private GameObject nextTerrain;

    [SerializeField] private float offset;

    public PlayerBehavior p;


    private void Start()
    {
        
    }

    private void Update()
    {
        ChangeTerrain(); // facem update la harta
    }


    private void ChangeTerrain()
    {
        if (p.next)
        {


            currentTerrain.transform.position += new Vector3(0.0f, 0.0f, offset);

            GameObject temp = currentTerrain;
            currentTerrain = nextTerrain;
            nextTerrain = temp;

            p.next = false;
        }
    }

}
