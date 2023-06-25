using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float rotationSpeed; //würde dann je nach schicht angepasst werden (evntl auf onEnter())
    public float movementSpeed = 1f; //könnte man erhöhen so wie man die punktzahl erhöht
    public float maxAngle;

    public float depth = 0; // how far did the drill go
    [SerializeField] private float maxDepth;
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private HighScoreManager highscoreManager;
    private float dirY = 0;
    private int currentPhase = 1;
    private int depthCounterObstacle = 0;
    private int depthCounterBackground = 0;
    [SerializeField] private int depthUpdateObstacleTrigger;
    [SerializeField] private int depthUpdateBackgroundTrigger;


    private float angle = 0f;

    public UnityEvent PhaseOneFinished;
    public UnityEvent PhaseTwoFinished;
    public UnityEvent PhaseThreeFinished;
    public UnityEvent SpawnFinishLine;
    public UnityEvent DepthUpdateObstacle;
    public UnityEvent DepthUpdateBackground;

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
        GameObject[] finish = GameObject.FindGameObjectsWithTag("Finish");
        GameObject[] background = GameObject.FindGameObjectsWithTag("Background");
        //GameObject[] both = (GameObject[])obstacles.Concat(finish);
        foreach (GameObject obj in obstacles)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dirY) * movementSpeed;
        }
        foreach (GameObject obj in finish)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dirY) * movementSpeed;
        }
        foreach (GameObject obj in background)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dirY) * movementSpeed;
        }
    }

    private void FixedUpdate()
    {
        depth += dirY * movementSpeed;
        int depthInt = (int) (depth * (-1));
        highscoreText.SetText(depthInt.ToString());
        highscoreManager.currentHighscore = depthInt;

        if (depthInt >= maxDepth / 4 && currentPhase == 1)
        {
            currentPhase = 2;
            PhaseOneFinished.Invoke();
        }
        else if (depthInt >= maxDepth / 2 && currentPhase == 2)
        {
            currentPhase = 3;
            PhaseTwoFinished.Invoke();
        } 
        else if(depthInt >= (maxDepth - maxDepth / 4) && currentPhase == 3)
        {
            currentPhase = 4;
            PhaseThreeFinished.Invoke();
        }
        else if(depthInt >= maxDepth && currentPhase == 4)
        {
            currentPhase = 5;
            SpawnFinishLine.Invoke();
        }

        if(depthCounterObstacle < (depthInt / depthUpdateObstacleTrigger))
        {
            depthCounterObstacle++;
            DepthUpdateObstacle.Invoke();
        }
        if (depthCounterBackground < (depthInt / depthUpdateBackgroundTrigger))
        {
            depthCounterBackground++;
            DepthUpdateBackground.Invoke();
        }
    }
}
