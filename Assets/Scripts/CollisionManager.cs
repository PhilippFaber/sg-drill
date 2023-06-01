using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private int health;
    public int maxHealth;
    private SpriteRenderer renderer;
    [Tooltip("Sprite that is displayed when the Drill has hit 0 Obstacles")]
    public Sprite defaultSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 1 Obstacles")]
    public Sprite damagedSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 2 Obstacles")]
    public Sprite demolishedSprite;
    [Tooltip("Sprite that is displayed when the Drill has hit 3 Obstacles")]
    public Sprite deadSprite;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        renderer = GetComponent<SpriteRenderer>();
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
        if (health >= maxHealth / 3 * 2 && health < maxHealth)
        {
            renderer.sprite = damagedSprite;
        }
        else if (health <= maxHealth/3)
        {
            renderer.sprite = demolishedSprite;
        }
        else
        {
            renderer.sprite = defaultSprite;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        renderer.sprite = deadSprite;
        GetComponent<PauseController>().GameOver();
    }

    public void FinishedGame()
    {
        Debug.Log("You Win");
        GetComponent<PauseController>().GameOver();
    }
}
