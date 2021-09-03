using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public void WriteCsv(){
        TextAsset africa =Resources.Load<TextAsset>("covid19_africa");
        TextAsset asia =Resources.Load<TextAsset>("covid19_asia");
        TextAsset europe =Resources.Load<TextAsset>("covid19_europe");
        TextAsset north_america =Resources.Load<TextAsset>("covid19_northamerica");
        TextAsset south_america =Resources.Load<TextAsset>("covid19_southamerica");
        TextAsset oceania =Resources.Load<TextAsset>("covid19_oceania");


        //Africa
        string[] data = oceania.text.Split(new char[] { '\n' });
        List<string> result_africa_arr=new List<string>();
        string result_africa="";
        int loop=1;
        for(int i=1;i<data.Length-1;i++){
            Debug.Log(loop);loop++;
            string[] row = data[i].Split(new char[] { ',' });
            bool flag=false;
            for(int j=0;j<result_africa_arr.Count;j++){
                if(row[1]==result_africa_arr[j]){
                    flag=true;
                }
            }
            if(!flag){
                result_africa_arr.Add(row[1]);
                result_africa+=row[1];
                result_africa+=",";
            }
        }
        File.WriteAllText(@"C:\Users\Ali Ozery\OneDrive\Desktop\CSV countries Write\Oceania-Countries.csv" , result_africa);
    }

    public void ReadCSV(){
        TextAsset countries =Resources.Load<TextAsset>("African-Countries");
        string[] list= countries.text.Split(new char[] { ',' });
        Debug.Log(list.Length);
        for(int i=0; i<list.Length;i++){
            Debug.Log(list[i]);
        }
    }
}