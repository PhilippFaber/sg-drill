using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Layer;

    private int currentLayer = 0;


    public void SpawnBackground()
    {
        Instantiate(Layer[currentLayer], new Vector3(0, -7, 0), transform.rotation);
    }

    public void EnterNewLayer()
    {
        currentLayer++;
    }
}
