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
    public string URL_SelectAllEvents="https://pentruarduino.000webhostapp.com/UniHack/selectAllEvents.php";
    public string URL_AddUser="https://pentruarduino.000webhostapp.com/UniHack/addUser.php";
    public string URL_AddEvent="https://pentruarduino.000webhostapp.com/UniHack/addEvent.php";
    public string URL_Update="https://pentruarduino.000webhostapp.com/UniHack/updateUser.php";
    public string URL_VerifLogin="https://pentruarduino.000webhostapp.com/UniHack/verifLogin.php";
    public string URL_VerifExist="https://pentruarduino.000webhostapp.com/verifExist.php";
    public string URL_SelectUserHisData="https://pentruarduino.000webhostapp.com/UniHack/selectUserHisData.php";
    public TMP_InputField categorie,locatie,area,descriere,linksite,nrvoluntari,desfasurare,organizatori,asociatie,voluntari;
    
    public List<randData> usersData=new List<randData>();
    
    string[] dataVector;

    [Serializable]
    public class randData//un rand
    {
        public string tot;
        public string[] data;
    }
    public bool folosimFIsierul=false;
    void Start()
    {
        if(folosimFIsierul==true)
        StartCoroutine(StartGet());
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////select
    public void GetUserDataFromButton()
    {
        randData rd=new randData();
        StartCoroutine(GetUserDataI(email,parola));
    }
    randData rand;
    public void GetUserData(string email,string parola)
    {
        StartCoroutine(GetUserDataI(email,parola));
    }
    public IEnumerator GetUserDataI(string email,string parola)
    {
        
        WWWForm form=new WWWForm();
        form.AddField("verifEmail",email);
        form.AddField("verifParola",parola);
        WWW user=new WWW(URL_SelectUserHisData,form);
        yield return user;
        Debug.Log(user.text);
        string usersDataString=user.text;
        dateText.text=usersDataString;
        Debug.Log("am dat sa luam");
        
        //dataVector.Clear();
        //usersData.Clear();

        randData rd=new randData();
        rd.tot=usersDataString;
        rd.data=rd.tot.Split('|');
        TheManager.Instance.personalData=rd;
        //usersData.Add(rd);
    }
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
    public IEnumerator SelectEventsAfterCategories(List<string> categorii2)
    {
        if(categorii2==null || categorii2.Count==0)
            yield break;
        WWWForm form=new WWWForm();
        form.AddField("addNr",categorii2.Count);
        int j=0;
    
        foreach(string s in categorii2)
        {
            Debug.Log(s);
            j++;
            form.AddField("add"+j.ToString(),s);
        }
        
        Debug.Log("trimis selectCategorii");
        WWW events=new WWW(URL_SelectEventsAfterCategories,form);
        yield return events;
        string data=events.text;
        Debug.Log(data);
        string[] dataVector=data.Split(';');
        int n=dataVector.Length;
        //usersData.Clear();
        TheManager.Instance.evenimente.Clear();
        for(int i=0;i<n-1;i++)
        {
            randData rd=new randData();
            rd.tot=dataVector[i];
            rd.data=rd.tot.Split('|');
            TheManager.Instance.evenimente.Add(rd);
        }
        Debug.Log("gata selectCategorii");
        TheManager.Instance.primitEvents=true;
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
        Debug.Log("trimis sa creeze user");
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
        AddEvent(TheManager.Instance.categorieDrop.captionText.text,
        TheManager.Instance.locationInput.text,TheManager.Instance.areaDrop.captionText.text,
        TheManager.Instance.descriereInput.text,TheManager.Instance.siteInput.text,"",
        TheManager.Instance.desfasurareInput.text,TheManager.Instance.profilText.text,"",TheManager.Instance.profilText.text);
            //categorie.text,locatie.text,area.text,descriere.text,linksite.text,nrvoluntari.text,desfasurare.text,organizatori.text,asociatie.text,voluntari.text);
    }
    void AddEvent(string categorie,string locatie,string area,string descriere,string linksite,string nrvoluntari,string desfasurare,string organizatori,string asociatie,string voluntari)
    {
        if(area==">100")
        area="200";
        Debug.Log(categorie+locatie+area+descriere+linksite+nrvoluntari+desfasurare+organizatori+asociatie+voluntari);
        WWWForm form=new WWWForm();
        form.AddField("addCategorie",categorie);
        form.AddField("addLocatie",locatie);
        form.AddField("addArea",area);
        form.AddField("addDescriere",descriere);
        form.AddField("addLinksite",linksite);
        form.AddField("addNrvoluntari","1");
        form.AddField("addDesfasurare",desfasurare);
        form.AddField("addOrganizatori",organizatori);
        form.AddField("addAsociatie",asociatie);
        form.AddField("addVoluntari",voluntari);

        WWW www=new WWW(URL_AddEvent,form);
        dateText.text="Sent!";
        Debug.Log("trimis");
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
    public string confirmUnicitate;
    public void VerifExist(string email)
    {
        confirmUnicitate="";
        StartCoroutine(verifExist(email));
    }
    IEnumerator verifExist(string email)
    {
        confirmUnicitate="";
        WWWForm form=new WWWForm();
        form.AddField("verifEmail",email);
        WWW www=new WWW(URL_VerifExist,form);
        Debug.Log("trimis cu succes");
        yield return www;
        string textPrimit=www.text;
        if(textPrimit=="da")
        {
            //deja exista
            confirmUnicitate="nu";
            Debug.Log("exista deja");
        }
        else
        {
            //nu exista
            confirmUnicitate="da";
            Debug.Log("nu exista");
        }
        yield break;
    }
    public void VerifLoginFromButton()
    {
        email=TheManager.Instance.emailLogIn.text;
        parola=TheManager.Instance.parolaLogIn.text;
        //email=TheManager.Instance.email;
        //parola=TheManager.Instance.parola;
        VerifLogin(email,parola);
    }
    public string verifconfirmare;
    public void VerifLogin(string email,string parola)
    {
        verifconfirmare="";
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
            verifconfirmare="ok";
            TheManager.Instance.LogInDa();
            Debug.Log("Te ai logat cu succes");
        }
        else
        {
            //nu e bun
            verifconfirmare="nu";
            TheManager.Instance.LogInNu();
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
