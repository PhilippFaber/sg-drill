using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] buffs;

    public float widthOffset;
    public float minScale;
    public float maxScale;
    public float timerMax;

    private float timer = 0;

    // Update is called once per frame
    /*void Update()
    {
        if (timer > 0)
        {
            timer -= timerMax;
            //SpawnObstacle();
        }
        timer += Time.deltaTime;
    }*/

    public void SpawnObstacle()
    {
        float left = transform.position.x - widthOffset;
        float right = transform.position.x + widthOffset;
        float rotation = Random.Range(0, 360);
        float scale = Random.Range(minScale, maxScale);

        int decision = Random.Range(0, 100);
        if (decision <= 1)
        {//spawn buff
            GameObject newObject = Instantiate(buffs[0], new Vector3(Random.Range(left, right), transform.position.y),
            Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else //spawn obstacle
        {
            GameObject newObject = Instantiate(obstacles[UnityEngine.Random.Range(0, 5)], new Vector3(Random.Range(left, right), transform.position.y),
            Quaternion.Euler(new Vector3(0, 0, rotation)));
            newObject.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
