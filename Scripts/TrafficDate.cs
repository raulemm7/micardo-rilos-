using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TrafficDate : MonoBehaviour
{
    public TMP_Text dateText;
    public string URL_profilSelect="https://pentruarduino.000webhostapp.com/UniHack/profilSelect.php";
    public string URL_SelectEventsAfterCategories="https://pentruarduino.000webhostapp.com/UniHack/selectEventsAfterCategories.php";
    public string URL_AddUser="https://pentruarduino.000webhostapp.com/UniHack/addUser.php";
    public string URL_AddEvent="https://pentruarduino.000webhostapp.com/UniHack/addEvent.php";
    public string URL_Update="https://pentruarduino.000webhostapp.com/UniHack/updateUser.php";
    public string URL_VerifLogin="https://pentruarduino.000webhostapp.com/UniHack/verifLogin.php";
    public TMP_InputField categorie,locatie,area,descriere,linksite,nrvoluntari,desfasurare,organizatori,asociatie,voluntari;
    
    public List<randData> usersData=new List<randData>();
    
    string[] dataVector;

    [Serializable]
    public class randData//un rand
    {
        public string tot;
        public string[] data;
    }
    void Start()
    {
        StartCoroutine(StartGet());
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////select
    IEnumerator Wait2secAndStartGet()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(StartGet());
    }
    IEnumerator StartGet()
    {
        WWW users=new WWW(URL_profilSelect);
        yield return users;
        string usersDataString=users.text;
        dateText.text=usersDataString;
        Debug.Log("luat");
        
        //dataVector.Clear();
        dataVector=usersDataString.Split(';');

        int n=dataVector.Length;
        for(int i=0;i<n;i++)
        {
            randData rd=new randData();
            rd.tot=dataVector[i];
            rd.data=rd.tot.Split('|');
            usersData.Add(rd);
        }
        //string[] doua=usersDataFrumos[1].data[2].Split(':');
       // whereCondition=doua[1];

        //Debug.Log(ss);
        //testMessage.text=ss;
       // deTest.text=GetValueData(usersData[0],"username:");
       // Debug.Log(GetValueData(usersData[0],"username:"));
       yield return null;
       
    }
    public List<string> categorii=new List<string>();
    public IEnumerator SelectEventsAfterCategories(List<string> categorii)
    {
        if(categorii==null || categorii.Count==0)
            yield break;
        WWWForm form=new WWWForm();
        form.AddField("addNr",categorii.Count);
        int j=0;
            form.AddField("da",categorii[0]);
            /*
        foreach(string s in categorii)
        {
            Debug.Log(s);
            j++;
            form.AddField("id"+j.ToString(),s);
        }
        */
        Debug.Log("trimis selectCategorii");
        WWW events=new WWW(URL_SelectEventsAfterCategories);
        yield return events;
        string data=events.text;
        string[] dataVector=data.Split(';');
        int n=dataVector.Length;
        usersData.Clear();
        for(int i=0;i<n;i++)
        {
            randData rd=new randData();
            rd.tot=dataVector[i];
            rd.data=rd.tot.Split('|');
            usersData.Add(rd);
        }
        Debug.Log("gata selectCategorii");
        yield return null;

    }
    public void SelectCategoriiFromButton()
    {
        StartCoroutine(SelectEventsAfterCategories(categorii));
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////add

    public void AddUser(string nume,string prenume,string email,string parola,string nrTel,string tara,string judet,string oras,List<string> interese)
    {
        WWWForm form=new WWWForm();
        form.AddField("addNume",nume);
        form.AddField("addPrenume",prenume);
        form.AddField("addEmail",email);
        form.AddField("addParola",parola);
        form.AddField("addNrTel",nrTel);
        form.AddField("addTara",tara);
        form.AddField("addJudet",judet);
        form.AddField("addOras",oras);
        string intereseCont="";
        foreach(string s in interese)
        {
            intereseCont=intereseCont+","+s;
        }
        form.AddField("addInterese",intereseCont);

        WWW www=new WWW(URL_AddUser,form);
        dateText.text="Sent!";
        //verificam daca putem sterge
        /*
        if(usersDataFrumos.Count>2)
        {
            string[] doua=usersDataFrumos[1].data[2].Split(':');//ex: password:123456
            whereCondition=doua[1];
            DeleteUser("password",doua[1]);
        }
        */
        StartCoroutine(Wait2secAndStartGet());
       // Debug.Log("pus cu succes");
    }
    public void AddEventFromButton()
    {
        AddEvent(categorie.text,locatie.text,area.text,descriere.text,linksite.text,nrvoluntari.text,desfasurare.text,organizatori.text,asociatie.text,voluntari.text);
    }
    void AddEvent(string categorie,string locatie,string area,string descriere,string linksite,string nrvoluntari,string desfasurare,string organizatori,string asociatie,string voluntari)
    {
        WWWForm form=new WWWForm();
        form.AddField("addCategorie",categorie);
        form.AddField("addLocatie",locatie);
        form.AddField("addArea",area);
        form.AddField("addDescriere",descriere);
        form.AddField("addLinksite",linksite);
        form.AddField("addNrvoluntari",nrvoluntari);
        form.AddField("addDesfasurare",desfasurare);
        form.AddField("addOrganizatori",organizatori);
        form.AddField("addAsociatie",asociatie);
        form.AddField("addVoluntari",voluntari);

        WWW www=new WWW(URL_AddEvent,form);
        dateText.text="Sent!";
        //verificam daca putem sterge
        /*
        if(usersDataFrumos.Count>2)
        {
            string[] doua=usersDataFrumos[1].data[2].Split(':');//ex: password:123456
            whereCondition=doua[1];
            DeleteUser("password",doua[1]);
        }
        */
        StartCoroutine(Wait2secAndStartGet());
       // Debug.Log("pus cu succes");
    }

    //////////////////////////////////////////////////////////////////////////////////// verificari
    public void VerifLoginFromButton()
    {
        VerifLogin(email,parola);
    }
    public void VerifLogin(string email,string parola)
    {
        StartCoroutine(verifLogin(email,parola));
    }
    IEnumerator verifLogin(string email,string parola)
    {
        WWWForm form=new WWWForm();
        form.AddField("verifEmail",email);
        form.AddField("verifParola",parola);
        WWW www=new WWW(URL_VerifLogin,form);
        Debug.Log("trimis cu succes");
        yield return www;
        string textPrimit=www.text;
        if(textPrimit=="ok")
        {
            //ceva sa confirmi ca e bun
            Debug.Log("Te ai logat cu succes");
        }
        else
        {
            //nu e bun
            Debug.Log("Email/Parola gresite");
        }
        yield break;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////update
    public void UpdateUserFromButton()
    {
        UpdateUser(email,parola,wf,wc);
    }
    public void UpdateUser(string email,string parola,string wf,string wc)
    {// actualizeaza userul care avea in tipul de date wf (ex username)  stringul wc (ex numele lui)
    // cu noile inputuri
    //////????????????????????????????
    Debug.Log("ce facem aici boss?");
    return;
        WWWForm form=new WWWForm();
        form.AddField("editEmail",email);
        form.AddField("editParola",parola);
        form.AddField("whereField",wf);
        form.AddField("whereCondition",wc);

        WWW www=new WWW(URL_Update,form);
        Debug.Log("actualizat cu succes");
        StartCoroutine(Wait2secAndStartGet());
    }
    public string email,parola,wf,wc;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("start...");
            UpdateUser(email,parola,wf,wc);
            //StartCoroutine(Wait2secAndStartGet());
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("verif...");
            VerifLogin(email,parola);
            //StartCoroutine(Wait2secAndStartGet());
        }
    }
}
