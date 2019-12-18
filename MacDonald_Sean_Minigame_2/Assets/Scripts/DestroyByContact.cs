using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public string tagToDestroy;
    public GameObject playerExplosion, enemyExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagToDestroy))
        {
            // destroys collision object (PlayerShot/ EnemyShot)
            //if(this.gameObject.tag != "Enemy")
            Destroy(this.gameObject);

            // Enemy ship takes damage/ is destroyed, gives points if latter
            if (tagToDestroy == "Enemy" && !collision.GetComponent<Enemy>().immune)
            {
                Instantiate(enemyExplosion, collision.transform.position, collision.transform.rotation);
                collision.GetComponent<Enemy>().LoseALife();  // reduces enemy life by 1
            }
            else if (tagToDestroy == "Player" && !collision.GetComponent<PlayerController>().immune)
            {
                Instantiate(playerExplosion, collision.transform.position, collision.transform.rotation);
                collision.GetComponent<PlayerController>().LoseALife();  // reduces life by 1
            }



        }
    }








}
