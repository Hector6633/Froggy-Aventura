using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class Itemcollector : MonoBehaviour
{


    public int food;

    public Text high;

    [SerializeField] Text foodtext;


    [SerializeField] AudioSource collection;

    public void Start()
    {
        PlayerPrefs.SetFloat("high", food);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("food"))
        {
            collection.Play();
            Destroy(collision.gameObject);
            food++;
            foodtext.text = "SCORE:" + food;
        }
       
       
    }

 


}
