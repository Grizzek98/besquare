using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGravity : MonoBehaviour
{
    public float portalBasePull = 100;
    public float minDistance = 10;
    private GameObject player;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // float attractionStrength = portalBasePull * 0.5f;

        // player = GameObject.FindGameObjectWithTag("Player");
        // if (player)
        // {
        //     var distance = Vector3.Distance(transform.position, player.transform.position);
        //     if (distance < transform.localScale.x * 0.5 + 50);
        //     {
        //         float magsqr;
        //         Vector3 offset;
        //         offset = transform.position - player.transform.position;
        //         offset.z = 0;
        //         magsqr = offset.sqrMagnitude;
        //         Debug.Log(magsqr);
        //         if (magsqr < 30)
        //         {
        //             player.GetComponent<Rigidbody2D>().AddForce((attractionStrength * offset.normalized / magsqr * 0.3f));
        //         }
        //     }
        // }

        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                Vector3 offset = transform.position - player.transform.position;
                player.GetComponent<Rigidbody2D>().AddForce((portalBasePull * offset.normalized));
            }
        }
    }
}
