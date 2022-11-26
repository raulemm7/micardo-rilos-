using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddEventScript : MonoBehaviour
{
    public TMP_InputField categorie,locatie,area,descriere,linksite,nrvoluntari,desfasurare,organizatori,voluntari;
    // Start is called before the first frame update
    public string URL_AddEvent="https://pentruarduino.000webhostapp.com/UniHack/addEvent.php";
    public TrafficDate traffic;

    void Start()
    {
        
    }
    public void AddEventFromButton()
    {
        AddEvent(categorie.text,locatie.text,area.text,descriere.text,linksite.text,nrvoluntari.text,desfasurare.text,organizatori.text,voluntari.text);
    }
    void AddEvent(string categorie,string locatie,string area,string descriere,string linksite,string nrvoluntari,string desfasurare,string organizatori,string voluntari)
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
        form.AddField("addVoluntaris",voluntari);

        WWW www=new WWW(URL_AddEvent,form);
        //dateText.text="Sent!";
        //verificam daca putem sterge
        /*
        if(usersDataFrumos.Count>2)
        {
            string[] doua=usersDataFrumos[1].data[2].Split(':');//ex: password:123456
            whereCondition=doua[1];
            DeleteUser("password",doua[1]);
        }
        */
        //StartCoroutine(traffic.Wait2secAndStartGet());
       // Debug.Log("pus cu succes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
