using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq.Expressions;
using BarGraph.VittorCloud;

public class BarGraphExample : MonoBehaviour
{
    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    BarGraphGenerator barGraphGenerator;

    public int start_index=1;


    public string continent_selected;

    public List<string> countries_in_continent= new List<string>();
    public Dictionary<string,Color> country_colors = new Dictionary<string, Color>();
    public List<Color> country_colors2= new List<Color>();

    // public GameObject DataHolder;

    // public int starting_index=20;
    // public int ending_index=22;
    // public List<int> column_index;      //use later to plot multiple columns
    void Start()
    {
        barGraphGenerator = GetComponent<BarGraphGenerator>();
        //SetSize();
        //CSVtoDataSet();
        SetColor();
        GetDataToPlot();
        //RemoveExcess();
        //if the exampleDataSet list is empty then return.
        if (exampleDataSet.Count == 0)
        {

            Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);
        gameObject.transform.parent.localScale=new Vector3(0.1f,0.1f,0.1f);

    }
    public void Update_Graph(){
        GameObject.FindGameObjectWithTag("Bar_Graph").transform.parent.transform.localScale= new Vector3(1f,1f,1f);
        GameObject.FindGameObjectWithTag("Bar_Graph").transform.localScale= new Vector3(1f,1f,1f);
        Destroy(transform.GetChild(0).gameObject);
        Start();
    }
    
    void SetSize(){
        GameObject selected= GameObject.FindGameObjectWithTag("Selected_Point_Holder_Dont_Destroy");
        int size = selected.GetComponent<SelecPointsDontDestroyScript>().point_data.Count;
        Debug.Log("Num of Selected: " + size);
        //exampleDataSet= new List<BarGraphDataSet>(size);
        for(int i=0; i<size;i++){
            BarGraphDataSet bar= new BarGraphDataSet(new List<XYBarValues>(4));
            exampleDataSet.Add(bar);
        }
        Debug.Log("example: " +exampleDataSet.Count);
        barGraphGenerator = GetComponent<BarGraphGenerator>();
    }

   
    //call when the graph starting animation completed,  for updating the data on run time
    public void StartUpdatingGraph()
    {

       
        //StartCoroutine(CreateDataSet());
    }



    IEnumerator CreateDataSet()
    {
        //  yield return new WaitForSeconds(3.0f);
        while (true)
        {

            GenerateRandomData();

            yield return new WaitForSeconds(2.0f);

        }

    }



    //Generates the random data for the created bars
    void GenerateRandomData()
    {
        
        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(barGraphGenerator.yMinValue, barGraphGenerator.yMaxValue);
        barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
    }

    void InitExampleDataSet(int length){
        exampleDataSet= new List<BarGraphDataSet>(length);
        Debug.Log(exampleDataSet.Count);
    } 
    // void RemoveExcess(){
    //     foreach(BarGraphDataSet bar in exampleDataSet){
    //         if(bar.GroupName==null || bar.GroupName==""){
    //             exampleDataSet.Remove(bar);
    //         }
    //     }
    // }

    public string OverlayData(int index){
        string result="";

        string continent= GameObject.FindGameObjectWithTag("SelectedContinentHolder").GetComponent<Selected_Continent>().continent;
        TextAsset covidData;
        switch(continent){
            case("Africa"): covidData= Resources.Load<TextAsset>("covid19_africa"); continent_selected="Africa"; break;
            case("Asia"): covidData= Resources.Load<TextAsset>("covid19_asia"); continent_selected="Asia";break;
            case("Europe"): covidData= Resources.Load<TextAsset>("covid19_europe"); continent_selected="Europe";break;
            case("NorthAmerica"): covidData= Resources.Load<TextAsset>("covid19_northamerica"); continent_selected="NorthAmerica";break;
            case("SouthAmerica"): covidData= Resources.Load<TextAsset>("covid19_southamerica"); continent_selected="SouthAmerica";break;
            case("Oceania"): covidData= Resources.Load<TextAsset>("covid19_oceania"); continent_selected="Oceania";break;
            case("World"): covidData= Resources.Load<TextAsset>("covid19_world"); continent_selected="World";break;
            default: covidData= Resources.Load<TextAsset>("covid19_africa"); continent_selected="Africa";break;
        }
        string[] col_headers = covidData.text.Split(new char[] { '\n' })[0].Split(new char[] { ',' });  //Column names
        string[] temp_data= covidData.text.Split(new char[] { '\n' });

        string[] row= temp_data[start_index+index].Split(new char[] { ',' });
        for(int i=0;i<row.Length;i++){
            result+=col_headers[i]+": ";
            result+=row[i];
            result+="\n";
        }


        return result;
    }

    public GameObject Overlay;
    public Text overlay_text;
    public void DisplayOverlay(string info){
        Overlay.SetActive(true);
        overlay_text.text=info;

    }


    public void GetDataToPlot(){
        //string continent_selected="";
        string continent= GameObject.FindGameObjectWithTag("SelectedContinentHolder").GetComponent<Selected_Continent>().continent;
        // List<List<string>> data_selected= GameObject.FindGameObjectWithTag("Selected_Point_Holder_Dont_Destroy").GetComponent<SelecPointsDontDestroyScript>().point_data;
        // int num_of_selected_points= data_selected.Count;
        // // Debug.Log(num_of_selected_points);
        // // InitExampleDataSet(num_of_selected_points);
        // // Debug.Log("Init complete");


        TextAsset covidData;
        switch(continent){
            case("Africa"): covidData= Resources.Load<TextAsset>("covid19_africa"); continent_selected="Africa"; break;
            case("Asia"): covidData= Resources.Load<TextAsset>("covid19_asia"); continent_selected="Asia";break;
            case("Europe"): covidData= Resources.Load<TextAsset>("covid19_europe"); continent_selected="Europe";break;
            case("NorthAmerica"): covidData= Resources.Load<TextAsset>("covid19_northamerica"); continent_selected="NorthAmerica";break;
            case("SouthAmerica"): covidData= Resources.Load<TextAsset>("covid19_southamerica"); continent_selected="SouthAmerica";break;
            case("Oceania"): covidData= Resources.Load<TextAsset>("covid19_oceania"); continent_selected="Oceania";break;
            case("World"): covidData= Resources.Load<TextAsset>("covid19_world"); continent_selected="World";break;
            default: covidData= Resources.Load<TextAsset>("covid19_africa"); continent_selected="Africa";break;
        }
        string[] col_headers = covidData.text.Split(new char[] { '\n' })[0].Split(new char[] { ',' });  //Column names
        //test loop
        // foreach(string x in col_headers){
        //     Debug.Log(x);
        // }
        string[] temp_data= covidData.text.Split(new char[] { '\n' });
        

        if(!colors_set){
            ColorHelper();
        }
        
        int index=0;
        for(int i=start_index;i<start_index+50;i++){
            string[] row= temp_data[i].Split(new char[] { ',' });
            exampleDataSet[index].GroupName = row[0] + " " + row[1];
            exampleDataSet[index].ListOfBars[0].XValue = col_headers[3];
            exampleDataSet[index].ListOfBars[0].YValue = float.Parse(row[3]);
            exampleDataSet[index].ListOfBars[1].XValue = col_headers[4];
            exampleDataSet[index].ListOfBars[1].YValue = float.Parse(row[4]);
            exampleDataSet[index].ListOfBars[2].XValue = col_headers[5];
            exampleDataSet[index].ListOfBars[2].YValue = float.Parse(row[5]);
            exampleDataSet[index].ListOfBars[3].XValue = col_headers[6];
            exampleDataSet[index].ListOfBars[3].YValue = float.Parse(row[6]);
            // Debug.Log(row[1]);
            // Debug.Log("Country Colors: " +country_colors.Count);
            //Debug.Log(country_colors.Values);
            //Debug.Log("Bar Color: " +country_colors[row[1]]);
            Color tmp_color= country_colors[row[1]];
            exampleDataSet[index].barColor = tmp_color;
            index++;
        }

        // int index=0;
        // foreach(List<string> dpoint in data_selected){
        //     //exampleDataSet[index].ListOfBars= new List<XYBarValues>(4);
        //     exampleDataSet[index].GroupName = dpoint[0];
        //     exampleDataSet[index].ListOfBars[0].XValue= col_headers[3];
        //     exampleDataSet[index].ListOfBars[0].YValue= float.Parse(dpoint[3]);
        //     exampleDataSet[index].ListOfBars[1].XValue= col_headers[4];
        //     exampleDataSet[index].ListOfBars[1].YValue= float.Parse(dpoint[4]);
        //     exampleDataSet[index].ListOfBars[2].XValue= col_headers[5];
        //     exampleDataSet[index].ListOfBars[2].YValue= float.Parse(dpoint[5]);
        //     exampleDataSet[index].ListOfBars[3].XValue= col_headers[6];
        //     exampleDataSet[index].ListOfBars[3].YValue= float.Parse(dpoint[6]);
        //     index++;
        // }
        // Debug.Log("size after input " + exampleDataSet.Count);


    }
    public void SetColor(){


        float r=0.1f;
        float g=0.1f;
        float b=0.1f;
        TextAsset countries_continents= Resources.Load<TextAsset>("Countries-Continents");
        string[] countries = countries_continents.text.Split(new char[] { '\n' });
        int temp_color_int=1;
        int debug_temp=1;
        bool mix1,mix2,mix3;
        mix1=mix2=mix3=false;
        for(int i=1;i<countries.Length-1;i++){
            // Debug.Log("Color "+debug_temp);
            // debug_temp++;
            string country = countries[i].Split(new char[] { ',' })[1];
            
            //country_colors[country]= new Color(r,g,b,1f);
            country_colors2.Add(new Color(r,g,b,1f));
            if(temp_color_int==1){
                if(r<1f){       //R
                    r+=0.1f;
                }
                else{
                    r=0;
                    temp_color_int++;
                }
            }
            if(temp_color_int==2){      //G
                if(g<1f){
                    g+=0.1f;
                }
                else{
                    g=0;
                    temp_color_int++;
                }
            }
            if(temp_color_int==3){      //B
                if(b<1f){
                    b+=0.1f;
                }
                else{
                    b=0;
                    temp_color_int++;
                }
            }
            if(temp_color_int==4){      //RG
                if(g<1f)
                {
                    if(!mix1&&!mix2){
                        r+=0.15f;
                        mix1=true;
                    }
                    else if(mix1 && !mix2){
                        r-=0.15f;
                        g+=0.15f;
                        mix2=true;
                    }
                    else{
                        r+=0.15f;
                        mix1=mix2=false;
                    }
                }
                else{
                    temp_color_int++;
                }
            }
            if(temp_color_int==5){      //RB
                if(b<1f)
                {
                    if(!mix1&&!mix2){
                        r+=0.15f;
                        mix1=true;
                    }
                    else if(mix1 && !mix2){
                        r-=0.15f;
                        b+=0.15f;
                        mix2=true;
                    }
                    else{
                        r+=0.15f;
                        mix1=mix2=false;
                    }
                }
                else{
                    temp_color_int++;
                }
            }
            if(temp_color_int==6){      //GB
                if(b<1f)
                {
                    if(!mix1&&!mix2){
                        g+=0.15f;
                        mix1=true;
                    }
                    else if(mix1 && !mix2){
                        g-=0.15f;
                        b+=0.15f;
                        mix2=true;
                    }
                    else{
                        g+=0.15f;
                        mix1=mix2=false;
                    }
                }
                else{
                    temp_color_int++;
                }
            }
            if(temp_color_int>6){       //RGB
                break;
            }
        }

        

    }
    

    bool colors_set=false;
    void ColorHelper(){
        //Debug.Log("entered method");

        TextAsset countries_continents= new TextAsset();
        switch(continent_selected){
            case("Africa"): countries_continents=Resources.Load<TextAsset>("African-Countries");break;
            case("Asia"): countries_continents=Resources.Load<TextAsset>("Asian-Countries");break;
            case("Europe"): countries_continents=Resources.Load<TextAsset>("European-Countries");break;
            case("NorthAmerica"): countries_continents=Resources.Load<TextAsset>("North-American-Countries");break;
            case("SouthAmerica"): countries_continents=Resources.Load<TextAsset>("South-American-Countries");break;
            case("Oceania"): countries_continents=Resources.Load<TextAsset>("Oceania-Countries");break;
            //default: break;
        }
         string[] countries = countries_continents.text.Split(new char[] { ',' });
         Debug.Log("Num of countries: " + countries.Length);
         for(int i=0;i<countries.Length;i++){
             Debug.Log(countries[i]);
             country_colors.Add(countries[i], country_colors2[i]);
         }
         colors_set=true;
    }
}



