using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Overlayhandler : MonoBehaviour
{
    public GameObject Panel;
    public Text txt;

    public void OpenPanel(string Data){
        txt.text=Data;
        if(Panel!=null){
            Panel.SetActive(true);
        }

    }
    public void ClosePanel(){
        Panel.SetActive(false);
    }
}
