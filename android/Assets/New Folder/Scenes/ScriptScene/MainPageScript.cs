using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainPageScript : MonoBehaviour
{
    public Button[] menuButtons = { };
    public Sprite[] selectedSprite = { }, unselectedSprite = { };
    public GameObject infoPanel;
    int mask;

    // Start is called before the first frame update
    void Start()
    {
        //Initial state is main page
        mask = 1 << 2;


       // menuButtons[0].onClick.AddListener(pressSettings); 
       // menuButtons[1].onClick.AddListener(pressMap);
       // menuButtons[2].onClick.AddListener(pressHome);
       // menuButtons[3].onClick.AddListener(pressSearch);
       // menuButtons[4].onClick.AddListener(pressProfile);

        infoPanel.SetActive(false);
    }

    void SetCorrectCanvas(int mask)
    {
        int i;
        for(i = 0; i < 5; ++i)
        {
            if ((1 << i & mask) != 0)
                menuButtons[i].GetComponent<Image>().sprite = selectedSprite[i];
            else menuButtons[i].GetComponent<Image>().sprite = unselectedSprite[i];
        }
    }

    public void pressSettings()
    {
        mask = 1 << 0;
        Changes(mask);
    }

    public void pressMap()
    {
        mask = 1 << 1;
        Changes(mask);
    }

    public void pressHome()
    {
        mask = 1 << 2;
        Changes(mask);
    }

    public void pressSearch()
    {
        mask = 1 << 3;
        Changes(mask);
    }

    public void pressProfile()
    {
        mask = 1 << 4;
        Changes(mask);
    }

    void Changes(int mask)
    {
        SetCorrectCanvas(mask);
    }

    public void MoreDetails()
    {

    }
}
