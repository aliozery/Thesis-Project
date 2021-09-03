using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Handler : MonoBehaviour
{
    public  GameObject GameView;

    public void ScatterPlot(){
        GameView.GetComponent<View_Script>().SetScatter();
    }
    public void BarChart(){
        GameView.GetComponent<View_Script>().SetBar();
    }
}
