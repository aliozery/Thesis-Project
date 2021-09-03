using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Button_Bar : MonoBehaviour
{
    public GameObject overlay;

    public void OnClick(){
        overlay.SetActive(false);
    }
}
