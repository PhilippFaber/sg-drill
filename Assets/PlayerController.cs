using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float rotationSpeed = 200f; //würde dann je nach schicht angepasst werden (evntl auf onEnter())
    public float movementSpeed = 1f; //könnte man erhöhen so wie man die punktzahl erhöht


    private float angle = 0f;

    void Update()
    {
        //--------------adjust angle------------------
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            if (angle < 90) //verhindern, dass der Spieler nach oben kann
            {
                angle += rotationSpeed * Time.deltaTime;  //deltatime wegen hardware und so
            }
        }
        else
        {
            if (angle > -90) //verhindern, dass der Spieler nach oben kann
            {
                angle -= rotationSpeed * Time.deltaTime;
            }
        }
        //-------------use angle---------------------------
        transform.eulerAngles = new Vector3(0, 0, angle); //roation des Sprites / gesamten objektes
        float angleRadians = (90 - angle) * Mathf.PI / 180;
        float dirX = Mathf.Cos(angleRadians);  
        float dirY = -Mathf.Sin(angleRadians);  //sollte schon normalized sein

        //-----------actual movement--------------------
        myRigidBody.velocity = new Vector2(dirX, dirY) * movementSpeed;     //movement wird in physics loop gemacht... wir setzen nur speed

        /* oder halt so
        myRigidBody.velocity = new Vector2(dirX, 0) * movementSpeed;     //movement wird in physics loop gemacht... wir setzen nur speed

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        GameObject[] background = GameObject.FindGameObjectsWithTag("Background");
        GameObject[] both = (GameObject[])obstacles.Concat(background);
        foreach (GameObject obj in both)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, dirY) * movementSpeed;
        }
        */
    }
}
