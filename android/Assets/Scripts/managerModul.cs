using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerModul : MonoBehaviour
{
    public bool[] select;
    public GameObject[] fals;
    public GameObject[] adev;
   
    public void schimb(int i)
    {
        if(i!=0)
        {
            adev[0].SetActive(false);
            fals[0].SetActive(!false);
        }
        
        select[i] = !select[i];
        adev[i].SetActive(select[i]);
        fals[i].SetActive(!select[i]);
    }
    public void all(bool val)
    {
        int i;
        for(i=0;i<=10;i+=1)
        {
            select[i] = val;
            adev[i].SetActive(select[i]);
            fals[i].SetActive(!select[i]);
        }

    }
    
    private void Start()
    {
        all(false);
    }
    void Update()
    {
        int i;
        bool v0=true;
        for(i=1;i<=7;i+=1)
            v0=v0 && select[i];
        if(v0)
        {
            select[0] = true;
            adev[0].SetActive(true);
            fals[0].SetActive(!true);
        }
    }
}
