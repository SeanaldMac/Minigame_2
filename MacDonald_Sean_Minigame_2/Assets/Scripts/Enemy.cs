using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float shotDelay, immuneTime;
    public string enemyType;
    public int lives;
    public bool immune = false, bossYSet = false;

    Rigidbody2D rb;
    BoxCollider2D playArea;
    public Vector2 direction;
    public GameObject shot;
    public Transform shotSpawn1, shotSpawn2;




    void Start()
    {
        // spawn enemy at certain x value
        rb = GetComponent<Rigidbody2D>();
        direction.x = (0);
        rb.velocity = direction;
        if(enemyType == "Boss")
            StartCoroutine(Shoot(shotSpawn1, shotSpawn2, shotDelay));
        else
            StartCoroutine(Shoot(shotSpawn1, shotDelay));

        // call playArea object
        playArea = GameObject.Find("PlayArea").GetComponent<BoxCollider2D>();
    }

    // regular enemies shoot projectiles
    IEnumerator Shoot(Transform shotSpawn, float shotDelay)
    {
        // delay shots after spawn
        yield return new WaitForSeconds(shotDelay);

        // shoot with delay time in between
        while(true)
        {
            for (int i = -1; i <= 1; i++)
            {
                shot.GetComponent<EnemyShotMover>().direction = new Vector2(i, -2);
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            }
            yield return new WaitForSeconds(shotDelay);
        }

    }

    // boss ship shoots projectiles from 2 spots
    IEnumerator Shoot(Transform shotSpawn1, Transform shotSpawn2, float shotDelay)
    {
        // delay shots after spawn
        yield return new WaitForSeconds(shotDelay);

        // shoot with delay time in between
        while (true)
        {
            shot.transform.position = new Vector2(0, 0);

            for(int i = -3; i <= 3; i++)
            {
                shot.GetComponent<EnemyShotMover>().direction = new Vector2(i, -1);
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
                Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            }

            //Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            //Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            yield return new WaitForSeconds(shotDelay);
        }

    }

    public void LoseALife()
    {
        lives--;

        if (lives <= 0)
        {
            if (enemyType == "Boss")
            {
                PlayerController win = FindObjectOfType<PlayerController>();
                if (win.lives > 0)
                    win.Winner();
            }

            Destroy(gameObject);
        }
        else
            StartCoroutine(ImmunityCooldown());
    }

    IEnumerator ImmunityCooldown()
    {
        immune = true;
        yield return new WaitForSeconds(immuneTime);
        immune = false;   
    }

    private void Update()
    {

        // boss ship's y value stops decreasing when certain point is reached, moves back and forth across x axis
        if (enemyType == "Boss" && transform.position.y <= 6 && !bossYSet)
        {
            direction = new Vector2(1, 0);
            rb.velocity = direction;
            bossYSet = true;
        }

        // enemy hits play area, changes x direction
        if (rb.position.x > 2 && rb.velocity.x > 0)
        {
            direction = new Vector2(-Mathf.Abs(direction.x), 0);
            rb.velocity = direction;
        }
        else if (rb.position.x < -2 && rb.velocity.x < 0)
        {
            direction = new Vector2(Mathf.Abs(direction.x), 0);
            rb.velocity = direction;
        }


        }

    



}
