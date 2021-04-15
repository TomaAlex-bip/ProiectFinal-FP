using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator_withDestroy : MonoBehaviour
{

    [SerializeField] List<GameObject> obj = new List<GameObject>();

    [SerializeField] private float offset;

    [SerializeField] private PlayerBehavior p;

    [SerializeField] private float terrainLenght = 80; // a se schimba cu lungimea noului teren


    private void Update()
    {
        ChangeTerrain();
    }

    private GameObject RandomGameObjectGenerator()
    {
        GameObject g = obj[Random.Range(0, obj.Count)];
        return g;
    }


    private void ChangeTerrain()
    {
        if (p.next)
        {
            Debug.Log("Schimbam terenul");

            GameObject g = RandomGameObjectGenerator();
            
             var terrain = Instantiate(g, transform.localPosition, transform.rotation);

            
            terrain.transform.position += terrain.transform.TransformPoint(Vector3.forward * offset); // <3 <3 <3 cel mai bun lucru existent pe lumea asta, bine ca exista
            //imi muta obiectul in fata, exact ca si cum l-as muta din editor cu axele locale

            Destroy(p.currentTerrain);


            offset += terrainLenght;

            p.next = false;
        }
    }

}
