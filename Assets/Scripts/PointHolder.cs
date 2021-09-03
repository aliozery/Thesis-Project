using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHolder : MonoBehaviour
{
    public List<GameObject> DataPoints= new List<GameObject>();

    public List<GameObject> GetChildren(){
        List<GameObject> result=new List<GameObject>();
        //result= gameobject.GetChildren();
        
        for(int i=0;i< transform.childCount;i++){
            result.Add(transform.GetChild(i).gameObject);
        }

        return result;
    }
}
