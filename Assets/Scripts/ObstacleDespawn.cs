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
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (collision.transform.localScale.x > transform.localScale.x)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
