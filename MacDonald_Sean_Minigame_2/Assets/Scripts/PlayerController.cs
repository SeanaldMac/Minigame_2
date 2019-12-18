using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed, immuneTime, shotDelay;
    public bool canFire = true, immune = false;
    public int lives;

    Rigidbody2D rb;
    public BoxCollider2D playArea;
    public GameObject shot, gameOverPanel;
    public Transform shotSpawn;
    public SpriteRenderer sr;
    public Text livesText, gameOverText;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // sets initial lives to Text
        livesText.text = "";
        for(int i = 0; i < lives; i++)
        {
            livesText.text += "A";
        }
    }

    private void Update()
    {
        // moves the player
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveH, moveV);

        rb.velocity = move * speed;

        // set ship boundaries to playArea
        float clampX = Mathf.Clamp(rb.position.x, playArea.bounds.min.x, playArea.bounds.max.x);
        float clampY = Mathf.Clamp(rb.position.y, playArea.bounds.min.y, playArea.bounds.max.y);

        rb.position = new Vector2(clampX, clampY);

        // fire shot when 'space' is pressed
        if (Input.GetButtonDown("Shoot"))
            Shoot();

        // fire shot while 'space' is pressed
        if(Input.GetButton("Shoot") && canFire)
        {
            Shoot();
            StartCoroutine(ShotCooldown());
        }

        // 

    }

    // spawns a shot
    void Shoot()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    // cooldown between shots
    IEnumerator ShotCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(shotDelay);
        canFire = true;
    }

    // shows game over panel when player is destroyed
    private void OnDestroy()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // player defeats the boss and has won the game
    public void Winner()
    {
        if (lives > 0)
        {
            gameOverText.text = "YOU WIN";
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }
    }

    // reduces player's lives by 1, sets immunity period, destroys player if lives <= 0
    public void LoseALife()
    {
        lives--;
        livesText.text = "";
        for(int i = 0; i < lives; i++)
        {
            livesText.text += "A";
        }

        if (lives <= 0)
            Destroy(gameObject);
        else
            StartCoroutine(ImmunityCooldown());

    }

    // makes player immune for period of time, also changes color to show this
    IEnumerator ImmunityCooldown()
    {
        immune = true;
        sr.color = Color.red;
        yield return new WaitForSeconds(immuneTime);
        sr.color = Color.white;
        immune = false;
    }




}
