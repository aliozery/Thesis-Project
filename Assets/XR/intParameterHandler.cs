using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class intParameterHandler : MonoBehaviour
{
    public int beginning=1;
    public int end;
    bool canPlot=false;
    public GameObject index_holder;
    public GameObject Plotter;

    public void Enter_Start(string beg_par){

        if(int.Parse(beg_par)>0){
            Plotter.GetComponent<DataPlotterAli>().start=int.Parse(beg_par);
            Plotter.GetComponent<DataPlotterAli>().end=int.Parse(beg_par)+200;
            beginning=int.Parse(beg_par);
            Debug.Log("after parse: " +beginning);
            end=beginning+200;
        }
        //Debug.Log(beg);
        //index_holder.GetComponent<intParameterHandler>().beginning=int.Parse(beg_par);
        // if(index_holder.GetComponent<intParameterHandler>().end>1){
        //     Debug.Log("Enter_Start done");
            
        //     //CheckCondition();
        // }
    }
    public void PlotIndex(){
        Debug.Log("On Plot " + beginning + " " + end);
        Plotter.GetComponent<DataPlotterAli>().OnIndexChange(Plotter.GetComponent<DataPlotterAli>().start,Plotter.GetComponent<DataPlotterAli>().start+200);
    }
    // public void Enter_End(string end_par){     
    //     index_holder.GetComponent<intParameterHandler>().end=int.Parse(end_par);
    //     if(index_holder.GetComponent<intParameterHandler>().beginning>0){
    //         Debug.Log("Enter_End done");
            
    //         CheckCondition();
    //     }
    //     else{
    //         index_holder.GetComponent<intParameterHandler>().end=2;
    //         CheckCondition();
    //     }
    // }
    // void CheckCondition(){
    //     if(index_holder.GetComponent<intParameterHandler>().end>index_holder.GetComponent<intParameterHandler>().beginning)
    //     {
    //         if(index_holder.GetComponent<intParameterHandler>().beginning<1){
    //             index_holder.GetComponent<intParameterHandler>().beginning=1;
    //         }
    //         int range=index_holder.GetComponent<intParameterHandler>().end-index_holder.GetComponent<intParameterHandler>().beginning;
    //         if(range>500){
    //             Debug.Log("Range too large");
    //         }
    //         else if(range<50)
    //         {
    //             Plotter.GetComponent<DataPlotterAli>().OnIndexChange(index_holder.GetComponent<intParameterHandler>().beginning,index_holder.GetComponent<intParameterHandler>().beginning+50);
    //         }

    //         else{
    //             Debug.Log("Check Contition Satisfied " + index_holder.GetComponent<intParameterHandler>().beginning + " " +index_holder.GetComponent<intParameterHandler>().end);
    //             Plotter.GetComponent<DataPlotterAli>().OnIndexChange(index_holder.GetComponent<intParameterHandler>().beginning,index_holder.GetComponent<intParameterHandler>().end);
    //         }
    //     }
    // }
}
