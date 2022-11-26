using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogInScript : MonoBehaviour
{
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

        if(CheckInputData(mail, pass) == false)
        {
            invalidData.enabled = true;
            Debug.Log("Nu-i bun");
        }
        else
        {
            Debug.Log("Te-ai logat golane!");
        }
    }   

    bool CheckInputData(string mail, string pass)
    {
        return true;
    }
}
