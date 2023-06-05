using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float rotationSpeed = 200f; //würde dann je nach schicht angepasst werden (evntl auf onEnter())
    public float movementSpeed = 1f; //könnte man erhöhen so wie man die punktzahl erhöht
    public float maxAngle;

    public float depth = 0; // how far did the drill go
    private float dirY = 0;


    private float angle = 0f;

    void Update()
    {
        //--------------adjust angle------------------
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            if (angle < maxAngle) //verhindern, dass der Spieler nach oben kann
            {
                angle += rotationSpeed * Time.deltaTime;  //deltatime wegen hardware und so
            }
        }
        else
        {
            if (angle > -maxAngle) //verhindern, dass der Spieler nach oben kann
            {
                angle -= rotationSpeed * Time.deltaTime;
            }
        }
        //-------------use angle---------------------------
        transform.eulerAngles = new Vector3(0, 0, angle); //roation des Sprites / gesamten objektes
        float angleRadians = (90 - angle) * Mathf.PI / 180;
        float dirX = Mathf.Cos(angleRadians);  
        dirY = -Mathf.Sin(angleRadians);  //sollte schon normalized sein

        //-----------actual movement--------------------
        //myRigidBody.velocity = new Vector2(dirX, dirY) * movementSpeed;     //movement wird in physics loop gemacht... wir setzen nur speed

        
        myRigidBody.velocity = new Vector2(dirX, 0) * movementSpeed;     //movement wird in physics loop gemacht... wir setzen nur speed

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        //GameObject[] background = GameObject.FindGameObjectsWithTag("Background");
        //GameObject[] both = (GameObject[])obstacles.Concat(background);
        foreach (GameObject obj in obstacles)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dirY) * movementSpeed;
        }
    }

    private void FixedUpdate()
    {
        depth += dirY * movementSpeed;
    }
}
