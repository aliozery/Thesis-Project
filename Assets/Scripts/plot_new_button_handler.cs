using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot_new_button_handler : MonoBehaviour
{
    public GameObject plotter;

    public void OnClick(){
        plotter.GetComponent<DataPlotterAli>().NewPlotHelper();
    }
}
