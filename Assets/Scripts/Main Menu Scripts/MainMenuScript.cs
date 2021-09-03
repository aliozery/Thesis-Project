using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject continentHolder;
    public GameObject GameView;
    public void Select_Africa(){
        continentHolder.GetComponent<Selected_Continent>().continent="Africa";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_Asia(){
        continentHolder.GetComponent<Selected_Continent>().continent="Asia";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_SouthAmerica(){
        continentHolder.GetComponent<Selected_Continent>().continent="SouthAmerica";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_NorthAmerica(){
        continentHolder.GetComponent<Selected_Continent>().continent="NorthAmerica";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_Oceania(){
        continentHolder.GetComponent<Selected_Continent>().continent="Oceania";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_Europe(){
        continentHolder.GetComponent<Selected_Continent>().continent="Europe";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Select_World(){
        continentHolder.GetComponent<Selected_Continent>().continent="World";
        if(GameView.GetComponent<View_Script>().View=="ScatterPlot")
        {
            SceneManager.LoadScene("Main_ScatterPlot", LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene("BarChart", LoadSceneMode.Single);
        }
    }
    public void Return_To_Menu(){
        Destroy(GameObject.FindGameObjectWithTag("SelectedContinentHolder"));
        Destroy(GameObject.FindGameObjectWithTag("Game_View"));
        SceneManager.LoadScene("Start_Screen", LoadSceneMode.Single);
    }
    
}
