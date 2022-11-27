using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickOnMap : MonoBehaviour
{

    public Image image;
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
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);

                    Feed2.Instance2.category.text = category;
                    Feed2.Instance2.link.text = link;
                    Feed2.Instance2.description.text = description;
                    Feed2.Instance2.participants.text = participants;
                    Feed2.Instance2.organisers.text = organisers;
                    Feed2.Instance2.image = image;

                    info.SetActive(true);
                    //panel.SetActive(false);
                }
            }
        }
    }
}
