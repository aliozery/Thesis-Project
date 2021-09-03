using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Inspect_ButtonHandler : MonoBehaviour
{
    GameObject PointHolder;
    public GameObject selected_graph;
    public GameObject default_plotter;
    public GameObject s_holder;

    public GameObject Front_UI;

    bool isSelect=false;
    bool isPlot=true;

    void Start(){
        PointHolder= GameObject.FindGameObjectWithTag("Point_Holder");
    }

    void Update(){
        //PointHolder= GameObject.FindGameObjectWithTag("Point_Holder");
    }

    public void OnClick(){
        Debug.Log("Select Clicked");
        if(isSelect){
            isSelect=false;
            foreach(GameObject dp in (PointHolder.GetComponent<PointHolder>().DataPoints)){
                dp.GetComponent<dataBallHandler>().selectPointsActive=false;
            }
            gameObject.GetComponentInChildren<Text>().text="Select";
        }
        else{
            isSelect=true;
            foreach(GameObject dp in (PointHolder.GetComponent<PointHolder>().DataPoints)){
                dp.GetComponent<dataBallHandler>().selectPointsActive=true;
            }
             gameObject.GetComponentInChildren<Text>().text="Inspect";
        }
    }

    public void GoBack(){
        GameObject selected_holder= GameObject.FindGameObjectWithTag("SelectedPointHolder");
        selected_holder.GetComponent<SelectedPointHolder>().SelectedPoints= new List<GameObject>();
        selected_graph.SetActive(false);
        default_plotter.SetActive(true);
        Front_UI.SetActive(true);

        s_holder.GetComponent<s_holder_script>().ClearChildren();
        
        //Revisit
        
        // for(int i=0;i<PointHolder.GetComponent<PointHolder>().DataPoints.Count;i++){
        //     if(PointHolder.GetComponent<PointHolder>().DataPoints[i].GetComponent<dataBallHandler>().isSelected){
        //         PointHolder.GetComponent<PointHolder>().DataPoints[i].GetComponent<dataBallHandler>().PointUnselected();
        //     }
        // }


        // for(int i=0; i<PointHolder.GetComponent<PointHolder>().DataPoints.Count;i++){
        //     if(PointHolder.GetComponent<PointHolder>().DataPoints[i].material.color==Color.yellow){
        //         PointHolder.GetComponent<PointHolder>().DataPoints[i].isSelected=false;
        //         Vector3 scalechange= new Vector3(-0.2f,-0.2f,-0.2f);
        //         PointHolder.GetComponent<PointHolder>().DataPoints[i].transform.localScale+=scalechange;
        //         PointHolder.GetComponent<PointHolder>().DataPoints[i].GetComponent<Renderer>().material.material.color=PointHolder.GetComponent<PointHolder>().DataPoints[i].startColor;
        //     }
        // }
        //GameObject.FindGameObjectWithTag("Plotter_Default").SetActive(true);
        
    }

    public void PlotSelected()          //Adjust 
    {
        
        GameObject selected_holder= GameObject.FindGameObjectWithTag("SelectedPointHolder");

        GameObject selected_dont_destroy= GameObject.FindGameObjectWithTag("Selected_Point_Holder_Dont_Destroy");

        int debug_counter=1;
        for(int i=0;i<selected_holder.GetComponent<SelectedPointHolder>().SelectedPoints.Count;i++){
            List<string> temp= selected_holder.GetComponent<SelectedPointHolder>().SelectedPoints[i].GetComponent<dataBallHandler>().GetData_Caller();
            //Debug.Log("temp list count: " + temp.Count);
            selected_dont_destroy.GetComponent<SelecPointsDontDestroyScript>().point_data.Add(temp);
            //Debug.Log(debug_counter);
            debug_counter++;
        }
        //Debug.Log(selected_dont_destroy.GetComponent<SelecPointsDontDestroyScript>().point_data.Count);
        if(selected_holder.GetComponent<SelectedPointHolder>().SelectedPoints.Count==0){
            Debug.Log("Please select some points first");
        }
        else{
            selected_graph.SetActive(true);
            GameObject.FindGameObjectWithTag("Plotter_Default").SetActive(false);
            Front_UI.SetActive(false);
            GameObject s_plotter= GameObject.FindGameObjectWithTag("s_point_plotter");
            s_plotter.GetComponent<SelectedPointsPlotter>().PlotSelected();
            // DontDestroyOnLoad(selected_dont_destroy);
            // SceneManager.LoadScene("BarChart", LoadSceneMode.Single);

        }
    }

    public void PlotSelected_2(){
        List<GameObject> children= PointHolder.GetComponent<PointHolder>().GetChildren();
        Debug.Log(children.Count);
        Toggle_Select_Back();
        foreach(GameObject child in children){
            if(!child.GetComponent<dataBallHandler>().isSelected){
                child.SetActive(false);
            }
        }
        


    }
    public void GoBack_2(){
        List<GameObject> children= PointHolder.GetComponent<PointHolder>().GetChildren();
        Debug.Log(children.Count);
        Toggle_Select_Back();
        foreach(GameObject child in children){
            child.SetActive(true);
            if(child.GetComponent<dataBallHandler>().isSelected){
                child.GetComponent<dataBallHandler>().PointUnselected();
            }
        }
        
    }

    public Button Plot_Selected;
    public Button Back_Plot_Selected;

    void Toggle_Select_Back(){      //takes two click --fix
        if(isPlot){
            Plot_Selected.gameObject.SetActive(false);
            Back_Plot_Selected.gameObject.SetActive(true);
            isPlot=false;
        }
        else{
            Back_Plot_Selected.gameObject.SetActive(false);
            Plot_Selected.gameObject.SetActive(true);
            isPlot=true;
        }
    }


}
