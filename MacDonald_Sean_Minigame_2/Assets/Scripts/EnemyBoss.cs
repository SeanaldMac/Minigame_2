using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float shotDelay;

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
    }

    IEnumerator Shoot()
    {
        // delay shots after spawn
        yield return new WaitForSeconds(1);

        // shoot with delay time in between
        while (true)
        {
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            yield return new WaitForSeconds(shotDelay);
        }

    }
}
