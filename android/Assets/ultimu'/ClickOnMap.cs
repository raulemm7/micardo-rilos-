using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickOnMap : MonoBehaviour
{

    public Sprite image;
    public GameObject info;
    public string category, link, description, participants, organisers;

    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10000f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;
                    Debug.Log(touchedObject.name);

                    Debug.Log("Touched " + touchedObject.transform.name);
                    if(touchedObject.name=="Event1")
                        Feed2.Instance2.PuneDate(0);
                    else
                    if(touchedObject.name=="Event2")
                        Feed2.Instance2.PuneDate(1);
                    else
                    if(touchedObject.name=="Event3")
                        Feed2.Instance2.PuneDate(2);
                    else
                    if(touchedObject.name=="Event4")
                        Feed2.Instance2.PuneDate(3);
                    else
                    if(touchedObject.name=="Event5")
                        Feed2.Instance2.PuneDate(4);
                    else
                    if(touchedObject.name=="Event6")
                        Feed2.Instance2.PuneDate(5);
                    else
                        Feed2.Instance2.PuneDate(6);
                    
                    /*
                    if(touchedObject.name=="Event1")
                    {
                    Feed2.Instance2.category.text = category;
                    Feed2.Instance2.link.text = link;
                    Feed2.Instance2.description.text = description;
                    Feed2.Instance2.participants.text = participants;
                    Feed2.Instance2.organisers.text = organisers;
                    Feed2.Instance2.image = image;
                    }
                    */

                    info.SetActive(true);
                    //panel.SetActive(false);
                }
            }
        }
    }
}
