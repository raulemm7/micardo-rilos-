using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class InfoScript : MonoBehaviour
{
    public static InfoScript Instance;
    public GameObject info, panel;
    public TMP_Text category, link, description, participants, organisers;
    public Image image;

    void Awake()
    {
        Instance = this;
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

    public void imagePressed()
    {
        panel.SetActive(true);
        info.SetActive(false);
    }
}
