using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling_Script : MonoBehaviour
{
    public GameObject graph;

    public void Zoom_In(){
        if(graph.transform.localScale.x<3f){
        graph.transform.localScale+=new Vector3(0.05f,0.05f,0.05f);
        }    
    }

    public void Zoom_Out(){
        if(graph.transform.localScale.x>0.5f){
        graph.transform.localScale-=new Vector3(0.05f,0.05f,0.05f);
        }
    }
}
