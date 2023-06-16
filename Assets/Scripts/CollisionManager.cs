using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    public GameObject player;
    public GameObject DrillBody;
    public int maxHealth;
    [Tooltip("Sprite that is displayed when the Drill has hit 0 Obstacles")]
    public Sprite defaultSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 1 Obstacles")]
    public Sprite damagedSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 2 Obstacles")]
    public Sprite badlyDamagedSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 3 Obstacles")]
    public Sprite demolishedSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 4 Obstacles")]
    public Sprite crackedSprite;

    private int health;
    private SpriteRenderer renderer;

    private int currentLayer = 0;

    [Tooltip("The different rotation Speed for each Layer")]
    [SerializeField] private float[] rotationSpeeds;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        renderer = DrillBody.GetComponent<SpriteRenderer>();
        renderer.sprite = defaultSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Test" + collision.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            GameOver();
            health = 0;
        }else if (collision.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            DamagePlayer();
        }else if (collision.CompareTag("Finish"))
        {
            FinishedGame();
        }else if (collision.CompareTag("Background"))
        {
            if (collision.name.Contains("1") && currentLayer == 0)
            {
                GetComponent<PlayerController>().rotationSpeed = rotationSpeeds[currentLayer];
                currentLayer++;
            }else if (collision.name.Contains("2") && currentLayer == 1)
            {
                GetComponent<PlayerController>().rotationSpeed = rotationSpeeds[currentLayer];
                currentLayer++;
            }
            else if (collision.name.Contains("3") && currentLayer == 2)
            {
                GetComponent<PlayerController>().rotationSpeed = rotationSpeeds[currentLayer];
                currentLayer++;
            }
            else if (collision.name.Contains("4") && currentLayer == 3)
            {
                GetComponent<PlayerController>().rotationSpeed = rotationSpeeds[currentLayer];
                currentLayer++;
            }
            
        }
    }

    public void DamagePlayer()
    {
        health--;
        Debug.Log("Obstacle was hit. Current health: " + health);
        if (health <= 0)
        {
            GameOver();
            return;
        }
        if (health == maxHealth)
            renderer.sprite = defaultSprite;
        if (health == maxHealth - 1)
        {
            renderer.sprite = damagedSprite;
        }
        else if (health == maxHealth - 2)
        {
            renderer.sprite = badlyDamagedSprite;
        }
        else if (health == maxHealth - 3)
        {
            renderer.sprite = demolishedSprite;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        renderer.sprite = crackedSprite;
        GetComponent<PauseController>().GameOver();
    }

    public void FinishedGame()
    {
        Debug.Log("You Win");
        GetComponent<PauseController>().GameOver();
    }
}
