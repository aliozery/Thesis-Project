using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataBallHandler : MonoBehaviour
{

    Color startColor;
    public bool isSelected=false;
    public bool selectPointsActive=false;
    int objNum;
    GameObject DataHolder;
    GameObject SelectedPointHolder;

    GameObject OverlayHandler;

    public string country;
    void Start(){
        SelectedPointHolder= GameObject.FindGameObjectWithTag("SelectedPointHolder");
        startColor=gameObject.GetComponent<Renderer>().material.color;
        OverlayHandler=GameObject.FindGameObjectWithTag("OverlayHandler");
        DataHolder= GameObject.FindGameObjectWithTag("DataHolder");
        string name= gameObject.name;
        string temp="";
        bool id=false;
        for(int i=0; i<name.Length;i++){
            if(id){
                temp+=name[i];
            }
            if(name[i]=='f'){
                id=true;
            }
        }
        objNum=int.Parse(temp);

    }

    void OnMouseDown(){
        if(!selectPointsActive)
        {
            Debug.Log("Start Mouse Down");
            Debug.Log(country);
            Debug.Log(transform.position.x);
            // DataHolder.GetComponent<Data>().DisplayData(objNum);
            string data= DataHolder.GetComponent<Data>().DisplayData(objNum);
            OverlayHandler.GetComponent<Overlayhandler>().OpenPanel(data);
            Debug.Log("End Mouse Down");
            // Debug.Log(objNum);
            // List<string> row_data= DataHolder.GetComponent<Data>().objData[objNum];
            // for(int i=0;i<row_data.Count;i++){
            //     Debug.Log(row_data[i]);
            // }
        }
        else if(isSelected){
            PointUnselected();
        }
        else{
            PointSelected();
        }
    }
    public List<string> GetData_Caller(){
        return DataHolder.GetComponent<Data>().GetData(objNum);
    }

    public void PointSelected(){
        SelectedPointHolder.GetComponent<SelectedPointHolder>().SelectedPoints.Add(gameObject);
        //Debug.Log(SelectedPointHolder.GetComponent<SelectedPointHolder>().SelectedPoints[1].name);
        //Debug.Log(startColor);
        isSelected=true;
        Vector3 scalechange= new Vector3(0.05f,0.05f,0.05f);
        gameObject.transform.localScale+=scalechange;
        gameObject.GetComponent<Renderer>().material.color=Color.white;
        //Debug.Log(gameObject.GetComponent<Renderer>().material.color);
    }
    public void PointUnselected(){
        //Debug.Log(SelectedPointHolder.GetComponent<SelectedPointHolder>().SelectedPoints[1].name);
        SelectedPointHolder.GetComponent<SelectedPointHolder>().SelectedPoints.Remove(gameObject);
        isSelected=false;
        Vector3 scalechange= new Vector3(-0.05f,-0.05f,-0.05f);
        gameObject.transform.localScale+=scalechange;
        gameObject.GetComponent<Renderer>().material.color=startColor;
    }

}
