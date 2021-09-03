using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Button_Handler_Bar : MonoBehaviour
{
    public void BackButton(){
        SceneManager.LoadScene("Start_Screen", LoadSceneMode.Single);
    }
}
