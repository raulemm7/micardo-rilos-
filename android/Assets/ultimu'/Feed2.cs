using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Feed2 : MonoBehaviour
{
    public static Feed2 Instance2;
    public GameObject info;//, panel;
    public TMP_Text category, link, description, participants, organisers;
    public Image image;
    public ClickOnMap[] clickuri;

    void Awake()
    {
        Instance2 = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PostScript.Instance.categorie
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PuneDate(int k)
    {
        category.text=clickuri[k].category;
        link.text=clickuri[k].link;
        description.text=clickuri[k].description;
        participants.text=clickuri[k].participants;
        organisers.text=clickuri[k].organisers;
        image.sprite=clickuri[k].image;
    }

    public void imagePressed()
    {
        // panel.SetActive(true);
        info.SetActive(false);
    }
}
