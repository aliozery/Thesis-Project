using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Bar : MonoBehaviour
{
    public GameObject graph;

    public void ClockWise(){
        graph.transform.Rotate(0f,10f,0f,Space.Self);
    }
    public void AntiClockWise(){
        graph.transform.Rotate(0f,-10f,0f,Space.Self);
    }

}
