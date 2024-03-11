using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerfinish : MonoBehaviour
{
    [SerializeField] AudioSource finishsfx;
    void Start()
    {
        finishsfx=GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            finishsfx.Play();
            completelvl();
        }
    }

    void completelvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
