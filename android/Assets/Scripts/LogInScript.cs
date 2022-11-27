using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogInScript : MonoBehaviour
{
    public TrafficDate trafficDate;
    public TMP_InputField mailInput, passInput;
    public TMP_Text invalidData;
    string mail, pass;
    public Button button;

    void Start()
    {
        invalidData.enabled = false;
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        mail = mailInput.text;
        pass = passInput.text;
        StartCoroutine(StartVerificare(mail,pass));
    }
    IEnumerator StartVerificare(string email,string parola)
    {
        trafficDate.verifconfirmare="";
        trafficDate.VerifLogin(email,parola);
        while(trafficDate.verifconfirmare=="")
        {
            yield return null;
        }
        if(trafficDate.verifconfirmare=="ok")
        {
            //bunnnn
            Debug.Log("bunnn");
        }
        else
        {
            invalidData.enabled = true;
            Debug.Log("Nu-i bun");
        }
        yield break;

    }
}
