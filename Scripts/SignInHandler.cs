using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class User
{
    public string mail = "", firstName = "", secondName = "", pass = "", tel = "";
    public string country = "", county = "", town = "";
    public List<string> interests = new List<string>();
}

public class SignInHandler : MonoBehaviour
{
    public TMP_InputField mail, firstName, secondName, pass, tel;
    public TMP_Dropdown country, county, town, interest1, interest2, interest3;
    public TMP_Text invalidMail, invalidPass, invalidFirst, invalidSecond, invalidTel, invalidCountry, invalidCounty, invalidTown, invalidInterest1, invalidInterest2, invalidInterest3;
    public Canvas firstScreen, secondScreen, thirdScreen;
 
    public Button SIButton, SecondButton;
    private User user = new User();
    
    // Start is called before the first frame update
    void Start()
    {
        SIButton.onClick.AddListener(TaskOnClick);
        SecondButton.onClick.AddListener(TaskOnClick2);

        invalidMail.enabled = false;
        invalidFirst.enabled = false;
        invalidSecond.enabled = false;
        invalidPass.enabled = false;
        invalidTel.enabled = false;
        secondScreen.enabled = false;
        thirdScreen.enabled = false;
        firstScreen.enabled = true;

        invalidCountry.enabled = false;
        invalidCounty.enabled = false;
        invalidTown.enabled = false;

        invalidInterest1.enabled = false;
        invalidInterest2.enabled = false;
        invalidInterest3.enabled = false;

        user.interests.Add("");
        user.interests.Add("");
        user.interests.Add("");
    }

    void TaskOnClick()
    {
        AssignData();
        bool validData = CheckData();

        if (validData == true)
        {
            Debug.Log("First page finished");
            firstScreen.enabled = false;
            secondScreen.enabled = true;
        }
           
        else Debug.Log("Something is wrong");
    }

    void AssignData()
    {
        user.mail = mail.text;
        user.firstName = firstName.text;
        user.secondName = secondName.text;
        user.pass = pass.text;
        user.tel = tel.text;
    }


    //poor verification
    //checking only the existance of a prefix and a suffix
    bool CheckMail(string mail)
    {
        int i;
        bool result = false;
        for (i = 0; i < mail.Length; ++i)
            if (mail[i] == '@' && i + 1 < mail.Length)
            {
                invalidMail.enabled = false;
                result = true;
                break;
            }

        if (result == false)
            invalidMail.enabled = true;

        return result;
    }

    bool CheckTel(string tel)
    {
        if (tel.Length != 10)
        {
            invalidTel.enabled = true;
            return false;
        }
        invalidTel.enabled = false;
        return true;
    }

    //poor verification
    //checking only the nr of characters
    bool CheckPass(string pass)
    {
        bool result = false;
        if (pass.Length > 8)
        {
            invalidPass.enabled = false;
            result = true;
        }
        else
        {
            invalidPass.enabled = true;
            result = false;
        }


        return result;
    }


    //checking to not be empty
    bool CheckNameFirst(string first)
    {
        bool result = false;
        if (first.Length > 3)
        {
            invalidFirst.enabled = false;
            result = true;
        }
        else
        {
            invalidFirst.enabled = true;
            result = false;
        }

        return result;
    }

    bool CheckNameSecond(string second)
    {
        bool result = false;
        if (second.Length > 3)
        {
            invalidSecond.enabled = false;
            result = true;
        }
        else
        {
            invalidSecond.enabled = true;
            result = false;
        }

        return result;
    }

    bool CheckData()
    {
        bool s1, s2, s3, s4, s5;
        s1 = CheckMail(user.mail);
        s2 = CheckPass(user.pass);
        s3 = CheckNameFirst(user.firstName);
        s4 = CheckNameSecond(user.secondName);
        s5 = CheckTel(user.tel);
        return s1 && s2 && s3 && s4 && s5;
    }

    void TaskOnClick2()
    {
        AssignDataSecondPage();
        bool validData = CheckDataSecondPage();

        if (validData == true)
        {
            Debug.Log("Account succesfully created!");
            secondScreen.enabled = false;
            thirdScreen.enabled = true;
        }
            
        else Debug.Log("Something is wrong");
    }


    void AssignDataSecondPage()
    {
        user.country = country.captionText.text;
        user.county = county.captionText.text;
        user.town = town.captionText.text;
        user.interests[0] = interest1.captionText.text;
        user.interests[1] = interest2.captionText.text;
        user.interests[2] = interest3.captionText.text;
    }


    bool CheckCountry(string c)
    {
        if (c == "Development" || c == "Country")
        {
            invalidCountry.enabled = true;
            return false;
        }

        invalidCountry.enabled = false;
        return true;
    }

    bool CheckCounty(string c)
    {
        if (c == "Development" || c == "County")
        {
            invalidCounty.enabled = true;
            return false;
        }
        invalidCounty.enabled = false;
        return true;
    }

    bool CheckTown(string t)
    {
        if (t == "Development" || t == "Town")
        {
            invalidTown.enabled = true;
            return false;
        }

        invalidTown.enabled = false;
        return true;
    }

    //town, country, county, interests
    bool CheckDataSecondPage()
    {
        bool s1, s2, s3, s4;
        s1 = CheckCountry(user.country);
        s2 = CheckCounty(user.county);
        s3 = CheckTown(user.town);
        s4 = CheckInterests(user.interests);

        return s1 && s2 && s3 && s4;
    }

    bool CheckInterests(List <string> interests)
    {
        bool s1, s2, s3;

        if (interests[0] == "Interest 1" || interests[0] == "Development")
        {
            s1 = false;
            invalidInterest1.enabled = true;
        }
        else
        {
            s1 = true;
            invalidInterest1.enabled = false;
        }

        if (interests[1] == "Interest 2" || interests[1] == "Development")
        {
            s2 = false;
            invalidInterest2.enabled = true;
        }
        else
        {
            s2 = true;
            invalidInterest2.enabled = false;
        }

        if (interests[2] == "Interest 3" || interests[2] == "Development")
        {
            s3 = false;
            invalidInterest3.enabled = true;
        }
        else
        {
            s3 = true;
            invalidInterest3.enabled = false;
        }
            

        if(interests[0] == interests[1])
        {
            s1 = false;
            invalidInterest1.enabled = true;
            s2 = false;
            invalidInterest2.enabled = true;
        }
        else if(interests[0] == interests[2])
        {
            s1 = false;
            invalidInterest1.enabled = true;
            s3 = false;
            invalidInterest3.enabled = true;
        }
        else if(interests[1] == interests[2])
        {
            s2 = false;
            invalidInterest2.enabled = true;
            s3 = false; 
            invalidInterest3.enabled = true;
        }

        return s1 && s2 && s3;
    }

}
