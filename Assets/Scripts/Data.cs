using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public List<List<string>> objData=new List<List<string>>();
    List<string> headers= new List<string>();
    void Start(){
        //SetHeaders();
    }
    void Update(){
        // if(headers.Count<0 && objData.Count>0){
        //     SetHeaders();
        // }
    }
    public void SetHeaders(){
        
        TextAsset covidData = Resources.Load<TextAsset>("covid19_africa");
        string[] data = covidData.text.Split(new char[] { '\n' });
        string[] temp_headers= data[0].Split(new char[] { ',' });
        foreach (string item in temp_headers)
        {
            headers.Add(item);   
        }    

    }
    public void SetObjData(List<List<string>> od){
        objData=od;
    }

    public string DisplayData(int index){
        string result="";
        List<string> row_data= objData[index];
        for(int i=0;i<row_data.Count;i++){
            result+= headers[i]+": ";
            result+=row_data[i];
            result+="\n";
            //Debug.Log(row_data[i]);
        }
        return result;
    }
    public List<string> GetData(int index){
        return objData[index];

    }
}
