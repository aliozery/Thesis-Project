using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPointsPlotter : MonoBehaviour
{
    public GameObject SelectedPointHolder;
    public GameObject s_holder;

    public GameObject PointPrefab;
    
    public void PlotSelected(){                         //Adjust/Redo
        List<GameObject> tempList=SelectedPointHolder.GetComponent<SelectedPointHolder>().SelectedPoints;
        float x;
        float y;
        float z;
        int i=0;
        int j=0;
        int k=0;
        int counterIndex=0;
        int counter=0;
        string xString="";
        for(int index=0; index<tempList.Count;index++)
        {
            Debug.Log("Loop "+ index);
            while(true){
                //Debug.Log("Loop 2");
                //Debug.Log(xString);
                if(tempList[index].name[i]=='x')
                {
                    Debug.Log("if condition");
                    j=i+1;
                    break;
                }
                xString+=tempList[index].name[i];
                Debug.Log(xString);
                i++;
            }
            x=float.Parse(xString);
            string yString="";
            while(true){
                if(tempList[index].name[j]=='y'){
                    k=j+1;
                    break;
                }
                yString+=tempList[index].name[j];
                j++;
            }
            y=float.Parse(yString);
            string zString="";
            while(true){
                if(tempList[index].name[k]=='f'){
                    counterIndex=k+1;
                    break;
                }
                zString+=tempList[index].name[k];
                k++;
            }
            z=float.Parse(zString);
            string counterString="";
            while(counterIndex<tempList[index].name.Length){
                counterString+=tempList[index].name[counterIndex];
                counterIndex++;
            }
            counter=int.Parse(counterString);

            GameObject dataPoint = Instantiate(
                    PointPrefab,
                    new Vector3(x,y,z) * 2 ,
                    Quaternion.identity);
            
            dataPoint.transform.parent = s_holder.transform;
            string dataPointName =x + "x " + y + "y " + z + "f" + counter;
            dataPoint.transform.name = dataPointName;
            
        }



    }
}
