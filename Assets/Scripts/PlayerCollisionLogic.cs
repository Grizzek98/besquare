using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    private int nextScene;
    private int currentScene;

    private bool startTimer = false;
    public float portalTimer = 2;

    public Transform portal;
    public GameObject button;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
        portal.GetComponent<ParticleSystem>().Stop();
    }

    void Update()
    {
        if (startTimer)
        {
            portalTimer -= Time.deltaTime;
            if (portalTimer < 0)
            {
                if (currentScene == 0)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                SceneManager.LoadScene(nextScene);
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.transform.tag == "KillSpace")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }




        if(col.transform.tag == "EndSpace")
        {
            portal.GetComponent<ParticleSystem>().Play();
            startTimer = true;
            if (button)
            {
                button.SetActive(false);
            }
            GetComponent<SquareMovement>().enabled = false;
            // rb.gravityScale = 0;
            
        }



        if(col.transform.tag == "EndSpaceStartGame")
        {
            // SceneManager.LoadScene(2);
        }


        if (col.transform.tag == "Lvl01")
        {
            SceneManager.LoadScene(2);
        }
        if (col.transform.tag == "Lvl02")
        {
            SceneManager.LoadScene(3);
        }
        if (col.transform.tag == "Lvl03")
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnColliderEnter2D(Collider2D col)
    {
        if(col.transform.tag == "PlatformBouncy")
        {
            
        }
    }
}
