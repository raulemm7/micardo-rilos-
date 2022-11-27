using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheManager : MonoBehaviour
{
    public static TheManager Instance;
    public TrafficDate trafficDate;
    public TMP_Text profilText,profilEmail,profilNrTel,profilTaraJudetOras,profilInterese,invalidData,invalidDataSignUp,invalidCreateEvent;
    public string email,parola;
    public Image pozaInfo;
    //butoane bara jos
    public Image settingsIm,pinIm,homeIm,searchIm,profileIm;
    public Sprite settingsSpGol,pinSpGol,homeSpGol,searchSpGol,profileSpGol;
    public Sprite settingsSpPlin,pinSpPlin,homeSpPlin,searchSpPlin,profileSpPlin;
    public bool stareSettings,starePin,stareHome,stareSearch,stareProfile;
    public TMP_InputField emailLogIn,parolaLogIn;
    public TMP_InputField prenumeInput,numeInput,emailInput,parolaInput,reparolaInput,phoneInput;
    public TMP_InputField descriereInput,locationInput,desfasurareInput,siteInput;
    public TMP_Dropdown categorieDrop,areaDrop;
    public TMP_Dropdown countryDrop,orasDrop,interes1Drop,interes2Drop;
    public GameObject[] panels;
    public GameObject baraJos;
    public int currentPanel=0;
    public bool logat=false;

    void Awake()
    {
        if(Instance==null)
            Instance=this;
    }
    void Start()
    {
        baraJos.SetActive(false);
        invalidData.text="";
        invalidDataSignUp.text="";
        invalidCreateEvent.text="";
        GetDataDinTelefon();
        logat=false;
        currentPanel=0;
        StartCoroutine(asteaptaLogin());
        if(email!="" && parola!="")//se presupune ca sunt bune
        {
            GetPersonalData();
        }
    }
    void GetDataDinTelefon()
    {

    }
    //0 log in
    //1 sign in
    //2 main
    public void LogInDa()
    {
        //save email+parola
        invalidData.text="";
        email=emailLogIn.text;
        parola=parolaLogIn.text;
        GetPersonalData();
    }
    public void LogInNu()
    {

        invalidData.text="Invalid Data.";
    }
    public IEnumerator asteaptaLogin()
    {
        while(logat==false)
        {
            yield return null;
        }
        nextPanel(2);
        baraJos.SetActive(true);
    }
    public void nextPanel(int k)
    {
        panels[currentPanel].SetActive(false);
        panels[k].SetActive(true);
        
        panels[6].SetActive(false);
        currentPanel=k;
    }
    public void GetPersonalData()
    {
        StartCoroutine(trafficDate.GetUserDataI(email,parola));
        StartCoroutine(asteapta());
    }
    public TrafficDate.randData personalData;
    IEnumerator asteapta()
    {
        while(personalData.data.Length==0)
        {
            yield return null;//asteapta....
        }
        TrafficDate.randData rd=personalData;
        Debug.Log(personalData.data.Length);
        profilText.text=personalData.data[0]+" "+personalData.data[1];
        profilEmail.text=rd.data[2];
        profilNrTel.text=rd.data[3];
        profilTaraJudetOras.text=rd.data[4]+rd.data[5]+rd.data[6];
        profilInterese.text=rd.data[7];
        logat=true;
        PuneToateEventurile();
    }
    


    public void verifSigUp()
    {
        if(prenumeInput.text=="")
        {
            invalidDataSignUp.text="First name?";
            return;
        }
        if(numeInput.text=="")
        {
            invalidDataSignUp.text="Second name?";
            return;
        }
        if(SignInHandler.Instance.CheckMail(emailInput.text)==false)
        {
            invalidDataSignUp.text="Invalid email";
            return;
        }
        if(SignInHandler.Instance.CheckTel(phoneInput.text)==false)
        {
            invalidDataSignUp.text="Invalid phone";
            return;
        }
        if(SignInHandler.Instance.CheckPass(parolaInput.text)==false)
        {
            invalidDataSignUp.text="Invalid password";
            return;
        }
        if(parolaInput.text!=reparolaInput.text)
        {
            invalidDataSignUp.text="Passwords don't match!";
            return;
        }

        if(countryDrop.value==0)
        {
            invalidDataSignUp.text="Select the country";
            return;
        }
        if(orasDrop.value==0)
        {
            invalidDataSignUp.text="Select the city";
            return;
        }
        if(interes1Drop.value==0)
        {
            invalidDataSignUp.text="Select the first Interest";
            return;
        }
        if(interes2Drop.value==0)
        {
            invalidDataSignUp.text="Select the second Interest";
            return;
        }
        StartCoroutine(SignInHandler.Instance.StartVerificare(emailInput.text));
    }
    public void SignedUp()
    {
        email=emailInput.text;
        parola=parolaInput.text;
        invalidData.text="";
        GetPersonalData();
    }


    public void verifAddEvent()
    {
        if(categorieDrop.value==0)
        {
            invalidCreateEvent.text="Select type";
            return;
        }
        if(descriereInput.text=="")
        {
            invalidCreateEvent.text="Write a description first";
            return;
        }
        if(desfasurareInput.text=="")
        {
            invalidCreateEvent.text="Select the date of event";
            return;
        }
        if(locationInput.text=="")
        {
            invalidCreateEvent.text="Select location";
            return;
        }
        if(areaDrop.value==0)
        {
            invalidCreateEvent.text="Select area";
            return;
        }
        invalidCreateEvent.text="";
        trafficDate.AddEventFromButton();
        nextPanel(2);
        
    }


    public List<string> listaPreferinte=new List<string>();
    public void AddEventInLista(string s)
    {
        if(listaPreferinte.Contains(s))
        return;
        listaPreferinte.Add(s);

    }
    public List<string> allEvents=new List<string>();
    public void AddAllEvents()
    {
        listaPreferinte=allEvents;
    }
    public void DeselectAll()
    {
        listaPreferinte.Clear();
    }
    public void RemoveEventInLista(string s)
    {
        if(listaPreferinte.Contains(s)==false)
        return;
        listaPreferinte.Remove(s);

    }
    public void SearchFromButton()
    {
        StartCoroutine(trafficDate.SelectEventsAfterCategories(listaPreferinte));
        StartCoroutine(asteaptaGettingEvents(true));
    }
    public void PuneToateEventurile()
    {
        listaPreferinte=allEvents;
        StartCoroutine(trafficDate.SelectEventsAfterCategories(allEvents));
        StartCoroutine(asteaptaGettingEvents(true));
        listaPreferinte.Clear();
    }
    public List<TrafficDate.randData> evenimente=new List<TrafficDate.randData>();
    public bool primitEvents;
    IEnumerator asteaptaGettingEvents(bool trece)
    {
        primitEvents=false;
        while(primitEvents==false)
        {
            yield return null;
        }
        //move la mainpage
        //punedata
        PunePostari();
        if(trece==true)
        {
        panels[6].SetActive(false);
        currentPanel=2;
        panels[2].SetActive(true);
        }
        //nextPanel(2);

    }
    public List<GameObject> obiecte=new List<GameObject>();

    public List<Postare> postari=new List<Postare>();
    public GameObject postareDefault;
    public Transform continut;
    public GameObject infoPanel;
    public TMP_Text participantiInfo,nrParticipantiInfo,descriereInfo,organizatoriInfo,locationInfo,categorieInfo;
    public void PunePostari()
    {
        foreach(GameObject G in obiecte)
        Destroy(G);
        obiecte=new List<GameObject>();
        obiecte.Clear();
        int i,n;
        n=evenimente.Count;
        for(i=0;i<n;i++)
        {
            GameObject X=Instantiate(postareDefault,transform.position,Quaternion.identity);
            X.transform.SetParent(continut);
            obiecte.Add(X);
            Postare p=X.GetComponent<Postare>();
            p.categorie=evenimente[i].data[0];
            p.locatie=evenimente[i].data[1];
            p.area=evenimente[i].data[2];
            p.descriere=evenimente[i].data[3];
            p.linkSite=evenimente[i].data[4];
            p.nrVoluntari=evenimente[i].data[5];
            p.organizatori=evenimente[i].data[6];
            p.asociatie=evenimente[i].data[7];
            p.voluntari=evenimente[i].data[8];
            p.puneDataLocal();
            postari.Add(p);
        }
    }
    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
    }
    public void ApasatSettings()
    {
        if(stareSettings)
        {
            //stareSettings++;
            //stareSettings%=2;
            //settingsIm.sprite=settingsSpGol;
        }
        else
        {
            stareSettings=false;starePin=false;stareHome=false;stareSearch=false;stareProfile=false;

            settingsIm.sprite=settingsSpGol;
            pinIm.sprite=pinSpGol;
            homeIm.sprite=homeSpGol;
            searchIm.sprite=searchSpGol;
            profileIm.sprite=profileSpGol;

            nextPanel(3);

            stareSettings=true;
            settingsIm.sprite=settingsSpPlin;
        }
    }
    public void ApasatPin()
    {
        if(starePin)
        {
            //starePin++;
            //starePin%=2;
            //pinIm.sprite=pinSpGol;
        }
        else
        {
            stareSettings=false;starePin=false;stareHome=false;stareSearch=false;stareProfile=false;

            settingsIm.sprite=settingsSpGol;
            pinIm.sprite=pinSpGol;
            homeIm.sprite=homeSpGol;
            searchIm.sprite=searchSpGol;
            profileIm.sprite=profileSpGol;

            nextPanel(5);

            starePin=true;
            pinIm.sprite=pinSpPlin;
        }
    }
    public void ApasatHome()
    {
        if(stareHome)
        {
            //stareHome++;
            //stareHome%=2;
            //homeIm.sprite=homeSpGol;
        }
        else
        {
            stareSettings=false;starePin=false;stareHome=false;stareSearch=false;stareProfile=false;

            settingsIm.sprite=settingsSpGol;
            pinIm.sprite=pinSpGol;
            homeIm.sprite=homeSpGol;
            searchIm.sprite=searchSpGol;
            profileIm.sprite=profileSpGol;

            nextPanel(2);

            stareHome=true;
            homeIm.sprite=homeSpPlin;
        }
    }
    public void ApasatSearch()
    {
        if(stareSearch)
        {
            //stareSearch++;
            //stareSearch%=2;
            //searchIm.sprite=searchSpGol;
        }
        else
        {
            stareSettings=false;starePin=false;stareHome=false;stareSearch=false;stareProfile=false;

            settingsIm.sprite=settingsSpGol;
            pinIm.sprite=pinSpGol;
            homeIm.sprite=homeSpGol;
            searchIm.sprite=searchSpGol;
            profileIm.sprite=profileSpGol;

            panels[6].SetActive(true);
            stareSearch=true;
            searchIm.sprite=searchSpPlin;
        }
    }
    public void ApasatProfile()
    {
        if(stareProfile)
        {
            //stareProfile++;
            //stareProfile%=2;
            //profileIm.sprite=profileSpGol;
        }
        else
        {
            stareSettings=false;starePin=false;stareHome=false;stareSearch=false;stareProfile=false;

            settingsIm.sprite=settingsSpGol;
            pinIm.sprite=pinSpGol;
            homeIm.sprite=homeSpGol;
            searchIm.sprite=searchSpGol;
            profileIm.sprite=profileSpGol;

            stareProfile=true;
            profileIm.sprite=profileSpPlin;
        }
    }
}
