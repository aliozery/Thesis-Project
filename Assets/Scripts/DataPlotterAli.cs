using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlotterAli : MonoBehaviour
{
    public GameObject ARcamera;
    public GameObject PointPrefab;
    public GameObject PointHolder;
    public GameObject DataHolder;

    public int index_x=3;
    public int index_y=4;
    public int index_z=5;

    int before_index_x=3;
    int before_index_y=4;
    int before_index_z=5;


    bool first_time_scaling=true;
    
    public int start=1;
    public int end=250;
    int counter=1;

    public float plotScale = 20f;

    public string continent_selected;

    public List<string> countries_in_continent= new List<string>();
    public Dictionary<string,Color> country_colors = new Dictionary<string, Color>();
    public List<Color> country_colors2= new List<Color>();

    void Start(){
        CSVtoDataSet();
        SetColor();
        //Debug.Log(country_colors2.Count);
        PlotData_Date();
        //PlotData();
        //Debug.Log(DataHolder.GetComponent<Data>().objData[1][0]);

    }
    public void OnIndexChange(int min, int max){
        switch(continent_selected){
            case("Africa"):
            if(max<15455){
                //Debug.Log("Entered Update method");
                start=min;
                end=max;
                UpdatedGraphPlot();
                //Debug.Log("Graph updated");
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
            case("Asia"):
            if(max<44161){
                start=min;
                end=max;
                UpdatedGraphPlot();
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
            case("Europe"):
            if(max<63892){
                start=min;
                end=max;
                UpdatedGraphPlot();
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
            case("NorthAmerica"):
            if(max<891768){
                start=min;
                end=max;
                UpdatedGraphPlot();
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
            case("SouthAmerica"):
            if(max<38453){
                start=min;
                end=max;
                UpdatedGraphPlot();
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
            case("Oceania"):
            if(max<3670){
                start=min;
                end=max;
                UpdatedGraphPlot();
            }
            else{
                Debug.Log("Index out of bounds");
            }
            break;
        }
    }
    public void UpdatedGraphPlot(){
        
        foreach (Transform child in PointHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        country_colors.Clear();
        country_colors2.Clear();
        PointHolder.GetComponent<PointHolder>().DataPoints= new List<GameObject>(); //reset list to be empty
        //Debug.Log("Before updating graph");
        CSVtoDataSet();
        //Debug.Log("After updating graph");
        SetColor();
        //Debug.Log(country_colors2.Count);
        PlotData_Date();
        //Debug.Log("New Graph Plotted");

    }
    public void NewPlotHelper()
    { //checks if new index values are input and calls plot data with new index
        if(index_x!=before_index_x && index_y != before_index_y && index_z!= before_index_z){   //all three values updated
            foreach (Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            PointHolder.GetComponent<PointHolder>().DataPoints= new List<GameObject>(); //reset list to be empty
            PlotData_Date();
            before_index_x=index_x;
            before_index_y=index_y;
            before_index_z=index_z;
        }
        else{
            Debug.Log("Missing one or more parameters");
        }


    }



    bool first_time_ball_scale=true;
    float ball_size;
    void PlotData_Date(){
        
        float z_counter=0;
        float z_increment=0.01f;
        List<List<string>> tempData=DataHolder.GetComponent<Data>().objData;
        //Debug.Log(tempData[0][1]+tempData[0][3]);
        string prev_date="";
        for(int i=0; i<tempData.Count;i++){ 
            //Debug.Log(tempData[i][index_x]);
            float x= float.Parse(tempData[i][index_x]);
            float y= float.Parse(tempData[i][index_y]);
            //Debug.Log("Done x and y");
            float xScaled=x;
            float yScaled=y;
            if(FindMax(index_x)>FindMin(index_x)){
                xScaled= (x-FindMin(index_x))/(FindMax(index_x)-FindMin(index_x));
            }
            else{
                xScaled=0f;
            }
            if(FindMax(index_y)>FindMin(index_y)){
                yScaled= (y-FindMin(index_y))/(FindMax(index_y)-FindMin(index_y));
            }
            else{
                yScaled=0f;
            }
            

            //Debug.Log("Done Scaling");

            GameObject dataPoint = Instantiate(PointPrefab,new Vector3(xScaled ,yScaled,z_counter) * plotScale,Quaternion.identity);

            
            dataPoint.GetComponent<dataBallHandler>().country=tempData[i][1];
            dataPoint.transform.parent = PointHolder.transform;
            string dataPointName = xScaled + "x " + yScaled + "y " + z_counter + "f" + counter;
            dataPoint.transform.name = dataPointName;
            //Debug.Log(tempData[i][1]);
            dataPoint.GetComponent<Renderer>().material.color = country_colors[tempData[i][1]];
            PointHolder.GetComponent<PointHolder>().DataPoints.Add(dataPoint);
            counter++;
            if(first_time_ball_scale){
                ball_size=dataPoint.transform.localScale.x;
                first_time_ball_scale=false;
            }
            dataPoint.transform.localScale=new Vector3(ball_size,ball_size,ball_size);
            Debug.Log("Size of ball: " + dataPoint.transform.localScale.x);
            if(tempData[i][0]!=prev_date){
                z_counter+=z_increment;
            }
            prev_date=tempData[i][0];
            //Debug.Log(prev_date);
            
            
            // switch(tempData[i][1]){      //testing color assignment per country
            //     case("Egypt"): dataPoint.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1.0f); break;
            //     case("Nigeria"): dataPoint.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1.0f); break;
            //     case("Ghana"):dataPoint.GetComponent<Renderer>().material.color = new Color(0, 0.4f, 0, 1.0f); break;
            //     case("South Africa"):dataPoint.GetComponent<Renderer>().material.color = new Color(0.4f, 0.4f, 0, 1.0f); break;
            //     case("Senegal"):dataPoint.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0, 1.0f); break;
            //     case("Equatorial Guinea"): dataPoint.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 1f, 1.0f); break;
            //     case("Ethiopia"):dataPoint.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 1f, 1.0f); break;
            //     case("Gabon"):dataPoint.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0.8f, 1.0f); break;
            //     case("Gambia"):dataPoint.GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0.2f, 1.0f); break;
            //     case("Libya"):dataPoint.GetComponent<Renderer>().material.color = new Color(0.5f, 0.1f, 0.8f, 1.0f); break;
            //     case("Morocco"):dataPoint.GetComponent<Renderer>().material.color = new Color(0.7f, 0f, 0.3f, 1.0f); break;
            // }
            

        }
        if(first_time_scaling){
            PointHolder.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
            first_time_scaling=false;
        }
        counter=0;
        z_counter=0f;
        //PointHolder.transform.localPosition=ARcamera.transform.localPosition;
    }
    // void PlotData(){
    //     List<List<string>> tempData=DataHolder.GetComponent<Data>().objData;
    //     for(int i=7000; i<11000; i++){
    //         int x= int.Parse(tempData[i][index_x]);
    //         int y=int.Parse(tempData[i][index_y]);
    //         int z= int.Parse(tempData[i][index_z]);

    //         float xScaled= (float)(x-FindMin(index_x))/(FindMax(index_x)-FindMin(index_x)) ;
    //         float yScaled=(float)(y-FindMin(index_y))/(FindMax(index_y)-FindMin(index_y)) ;
    //         float zScaled=(float)(z-FindMin(index_z))/(FindMax(index_z)-FindMin(index_z)) ;
            
    //         // Debug.Log( "X: " +xScaled);
    //         // Debug.Log("Y " +yScaled);
    //         // Debug.Log("Z "+zScaled);
            

    //         GameObject dataPoint = Instantiate(
    //                 PointPrefab,
    //                 new Vector3(xScaled,yScaled,zScaled) *plotScale,
    //                 Quaternion.identity);
    //         dataPoint.transform.parent = PointHolder.transform;
    //         string dataPointName =xScaled + "x " + yScaled + "y " + zScaled + "f" + counter;
    //         dataPoint.transform.name = dataPointName;
    //         PointHolder.GetComponent<PointHolder>().DataPoints.Add(dataPoint);
    //         counter++;
            
    //         // if(tempData[i][1]=="Egypt"){
    //         //     dataPoint.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1.0f);
    //         // }
    //         // else if(tempData[i][1]=="Nigeria"){
    //         //     dataPoint.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1.0f);
    //         // }

    //     }
    //     PointHolder.transform.localScale-=new Vector3(0.5f,0.5f,0.5f);
    //     counter=0;
    // }

    

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

        ColorHelper();

    }
    
    void ColorHelper(){
        Debug.Log("entered method");

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
             //Debug.Log(countries[i]);
             country_colors.Add(countries[i], country_colors2[i]);
         }
    }
    public void CSVtoDataSet()
    {
        Debug.Log("Entered CSV to dataset method");
        GameObject continent_holder= GameObject.FindGameObjectWithTag("SelectedContinentHolder");
        string continent= continent_holder.GetComponent<Selected_Continent>().continent;
        TextAsset covidData=new TextAsset();
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

        string[] data = covidData.text.Split(new char[] { '\n' });  //split by new line

        List<List<string>> final_data= new List<List<string>>();
        int testCount=1;
        Debug.Log("Beginning Loop " + start + " " + end);
        for (int i=start; i< end; i++)        //loop over rows
        {
            Debug.Log("Loop " +testCount+ " of loading data");
            testCount++;
            string[] row = data[i].Split(new char[] { ',' });
            List<string> row_data= new List<string>();
            for(int j=0; j<row.Length;j++){         //loop over values in single row
                row_data.Add(row[j]);
            }
            final_data.Add(row_data);
        }
        DataHolder.GetComponent<Data>().objData=final_data;
        DataHolder.GetComponent<Data>().SetHeaders();
    }

    int FindMax(int index){
        int max=0;
        List<List<string>> tempData=DataHolder.GetComponent<Data>().objData;
        for(int i=0; i<tempData.Count;i++){
            if(int.Parse(tempData[i][index])>max){
                max=int.Parse(tempData[i][index]);
            }
        }

        return max;
    }
     int FindMin(int index){
         List<List<string>> tempData=DataHolder.GetComponent<Data>().objData;
        int min= new int();//=int.Parse(tempData[start][index]);
        for(int i=0; i<tempData.Count;i++){
            if(int.Parse(tempData[i][index])<min){
                min=int.Parse(tempData[i][index]);
            }
        }

        return min;
    }
}