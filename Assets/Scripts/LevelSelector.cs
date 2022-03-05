using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public GameObject levelHolder;
    public GameObject levelIcon;
    public int numberOfLevels = 3;
    public GameObject thisCanvas;
    private Rect panelDimensions;


    // Start is called before the first frame update
    void Start()
    {
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        Rect iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt(panelDimensions.width / iconDimensions.width);
        int maxInACol = Mathf.FloorToInt(panelDimensions.height / iconDimensions.height);
        int amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
    }

    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;

        for(int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i-1), 0);
            LoadIcons(25, panel);
        }
        Destroy(panelClone);
    }

    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        for(int i = 1; i <= numberOfIcons; i++)
        {
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
