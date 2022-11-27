using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Postare : MonoBehaviour
{
    public TMP_Text nrParticipanti,nume,type;
    public Sprite gol,plin,golInima,plinInima;
    public Image steluta,inima,poza,pozaInfo;
    public Sprite cleaning,blood,help,planting,carol,teambuilding,sport;
    public bool participa=false,liked=false;
    public int nr;
    public string categorie,locatie,area,descriere,linkSite,nrVoluntari,desfasurare,organizatori,asociatie,voluntari;
    void Start()
    {
        
    }
    public void ApasatJoin()
    {
        if(participa==false)
        {
            participa=true;
            steluta.sprite=plin;
            nr++;
            nrVoluntari=nr.ToString();
            nrParticipanti.text=nr.ToString();
            StartCoroutine(participaCuEi());
        }
        else
        {
            participa=false;
            
            nr--;
            nrVoluntari=nr.ToString();
            nrParticipanti.text=nr.ToString();
            steluta.sprite=gol;
        }

    }
    public IEnumerator participaCuEi()
    {//add nume si prenume acolo
       // profilText.text
       /*
        WWWForm form=new WWWForm();
        form.AddField("addCategorie",categorie);
        form.AddField("addLocatie",locatie);
        form.AddField("addDescriere",descriere);
        form.AddField("addLinksite",linksite);
        form.AddField("addNrvoluntari",nrVoluntari);
        form.AddField("addNrvoluntariNou",nrVoluntari+1);
        form.AddField("addDesfasurare",desfasurare);
        form.AddField("addOrganizatori",organizatori);
        form.AddField("addAsociatie",asociatie);
        form.AddField("addVoluntari",voluntari);

        WWW www=new WWW(URL_AddEvent,form);
        dateText.text="Sent!";
        Debug.Log("trimis");
        */
       yield return null;
    }
    public void ApasatLike()
    {
        if(liked==false)
        {
            liked=true;
            inima.sprite=plinInima;
        }
        else
        {
            liked=false;
            inima.sprite=golInima;
        }

    }
    public void ActivateInfo()
    {
        TheManager.Instance.descriereInfo.text=descriere;
        TheManager.Instance.locationInfo.text=locatie;
        TheManager.Instance.categorieInfo.text=categorie;
        TheManager.Instance.organizatoriInfo.text=organizatori;
        TheManager.Instance.nrParticipantiInfo.text=nrVoluntari;
        TheManager.Instance.pozaInfo.sprite=poza.sprite;
        TheManager.Instance.ShowInfo();
    }
    public void puneDataLocal()
    {
        nrParticipanti.text=nrVoluntari;
        nume.text=organizatori;
        type.text=categorie;
        Int32.TryParse(nrVoluntari,out nr);
        if(categorie=="cleaning")
        poza.sprite=cleaning;
        else
        if(categorie=="planting")
        poza.sprite=planting;
        else
        if(categorie=="help families")
        poza.sprite=help;
        else
        if(categorie=="carol concert")
        poza.sprite=carol;
        else
        if(categorie=="sport")
        poza.sprite=cleaning;
        else
        poza.sprite=teambuilding;

        //TheManager.Instance.participantiInfo.text=voluntari;
        /*
        TheManager.Instance.descriereInfo.text=descriere;
        TheManager.Instance.locationInfo.text=locatie;
        TheManager.Instance.categorieInfo.text=categorie;
        TheManager.Instance.organizatoriInfo.text=organizatori;
        TheManager.Instance.nrParticipantiInfo.text=nrVoluntari;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
