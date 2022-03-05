using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpaceExitTransform : MonoBehaviour
{
    public float scaleFactor;
    private bool isGone = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while(!isGone)
        {
            while(0 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * scaleFactor;
                yield return null;
            }
            isGone = true;
        }
        Destroy(gameObject);
    }
}
