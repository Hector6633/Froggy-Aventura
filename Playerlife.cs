using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    Animator anim;

    Rigidbody2D rig;

    [SerializeField] AudioSource deathsfx;

    [SerializeField] AudioSource Rebornsfx;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();
    }

   public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="trap")
        {
          /*  deathsfx.Play();
            manager.gameover = true;
            rig.bodyType = RigidbodyType2D.Static;
            gameObject.SetActive(true);
            anim.SetTrigger("death");*/
           Die();
        }
    }

    void Die()
     {
         deathsfx.Play();
         rig.bodyType = RigidbodyType2D.Static;
         anim.SetTrigger("death");

     }

    public void Restartlvl()
    {
        //Rebornsfx.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
