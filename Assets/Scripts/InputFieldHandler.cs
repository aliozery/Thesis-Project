using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldHandler : MonoBehaviour
{
    public GameObject continent_holder;
    public GameObject bargraph;
    public void EnterStartIndex(string start_temp){
        continent_holder=GameObject.FindGameObjectWithTag("SelectedContinentHolder");

        int starting= int.Parse(start_temp);
        if(starting<1){
            starting=1;
            //pass it to start variable in example data set
        }
        else{
            int max_allowed=3619;
            switch(continent_holder.GetComponent<Selected_Continent>().continent){
                case("Africa"):max_allowed=15405;break;
                case("Asia"):max_allowed=44111;break;
                case("Europe"):max_allowed=63842; break;
                case("NorthAmerica"): max_allowed=891717;break;
                case("SouthAmerica"): max_allowed=38402; break;
                case("Oceania"):max_allowed=3619;break;
            }
            if(starting>max_allowed){
                starting=max_allowed;
            }

        }
        bargraph.GetComponent<BarGraphExample>().start_index=starting;

    }

    public void PlotNew(){
        bargraph.GetComponent<BarGraphExample>().Update_Graph();
    }
}
