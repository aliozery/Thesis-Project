using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler_X : MonoBehaviour
{

    public GameObject drop_y;       //Dropdown menu for y

    public GameObject drop_z;       //Dropdown menu for z
    
    public int index_selected_y;    //to check if index is already selected in legend

    public int index_selected_z;    //to check if index is already selected in legend

    GameObject dataPlotter;

    

    void Start()
    {
        dataPlotter= GameObject.FindGameObjectWithTag("Plotter_Default");


        var dropdown=  transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> items = new List<string>();

        string continent= GameObject.FindGameObjectWithTag("SelectedContinentHolder").GetComponent<Selected_Continent>().continent;
        TextAsset covidData=new TextAsset();
        switch(continent){
            case("Africa"): covidData= Resources.Load<TextAsset>("covid19_africa"); break;
            case("Asia"): covidData= Resources.Load<TextAsset>("covid19_asia");break;
            case("Europe"): covidData= Resources.Load<TextAsset>("covid19_europe");break;
            case("NorthAmerica"): covidData= Resources.Load<TextAsset>("covid19_northamerica");break;
            case("SouthAmerica"): covidData= Resources.Load<TextAsset>("covid19_southamerica"); break;
            case("Oceania"): covidData= Resources.Load<TextAsset>("covid19_oceania");break;
            case("World"): covidData= Resources.Load<TextAsset>("covid19_world");break;
            default: covidData= Resources.Load<TextAsset>("covid19_africa");break;
        }

        string[] data = covidData.text.Split(new char[] { '\n' });
        string[] row = data[0].Split(new char[] { ',' });

        foreach (string column in row)
        {
            items.Add(column);
        }
        foreach (string column in items)
        {
            dropdown.options.Add(new Dropdown.OptionData(){ text=column});
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
    }


    GameObject selected_continent_holder;
    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        

        
        
        // if(index>=1 && index<13 && index!=11){
        //     if(index==index_selected_y || index==index_selected_z){
        //         Debug.Log("Already chosen");
        //     }
        //     else{
        //         drop_y.GetComponent<DropDownHandler_Y>().index_selected_x=index;
        //         drop_z.GetComponent<DropDownHandler_Z>().index_selected_x=index;
        //         dataPlotter.GetComponent<DataPlotterAli>().index_x=index;

        //     }
        // }

        
        
    }


}
