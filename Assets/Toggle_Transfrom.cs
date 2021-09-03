using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Transfrom : MonoBehaviour
{
    public GameObject ARHandler;
    public bool toggle=true;
    public void OnClick(){
        if(ARHandler.GetComponent<ARTaptoPlaceObject>().transform){
            ARHandler.GetComponent<ARTaptoPlaceObject>().transform=false;
            gameObject.GetComponentInChildren<Text>().text="Toggle Movement: ON";
        }
        else{
            ARHandler.GetComponent<ARTaptoPlaceObject>().transform=true;
            gameObject.GetComponentInChildren<Text>().text="Toggle Movement: OFF";
        }
    }
}
