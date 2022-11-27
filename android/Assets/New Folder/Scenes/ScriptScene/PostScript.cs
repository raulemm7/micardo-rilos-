using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PostScript : MonoBehaviour
{
    //public static PostScript Instance;
    //public TMP_Text category, link, description, participants, organisers;
    public Image image;
    public GameObject panel, info;
    public string category, link, description, participants, organisers;
    // Start is called before the first frame update
    void Awake()
    {
        //Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressedButton()
    {
        InfoScript.Instance.category.text = category;
        InfoScript.Instance.link.text = link;
        InfoScript.Instance.description.text = description;
        InfoScript.Instance.participants.text = participants;
        InfoScript.Instance.organisers.text = organisers;
        InfoScript.Instance.image = image;

        info.SetActive(true);
        panel.SetActive(false);
    }
}
