using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawn : MonoBehaviour
{
    public float despawnLimit = 10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > despawnLimit)
        {
            print("hi");
            Destroy(gameObject);
            
        }
    }
}
