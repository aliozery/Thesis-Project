using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Script : MonoBehaviour
{
    public string View;

    void Start() {
        View="BarChart";    
    }
    public void SetBar(){
        View="BarChart";
    }
    public void SetScatter(){
        View="ScatterPlot";
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
