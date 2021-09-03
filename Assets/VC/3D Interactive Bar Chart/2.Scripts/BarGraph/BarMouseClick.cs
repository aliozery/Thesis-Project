using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BarGraph.VittorCloud
{
    public class BarMouseClick : MonoBehaviour
    {
        #region PublicVariables

        public Vector3 barScale;
        public Outline outline;

        public Action<GameObject> PointerDownOnBar;
        public Action<GameObject> PointerUpOnBar;
        public Action<GameObject> PointerEnterOnBar;
        public Action<GameObject> PointerExitOnBar;

        #endregion

        #region PrivateVariables

        GameObject bar;
        #endregion

        #region UnityCallBacks

        private void Awake()
        {
            bar = transform.parent.gameObject;
        }
        // Start is called before the first frame update
        void Start()
        {

            barScale = transform.localScale;
            outline.enabled = false;
        }



        #region UnityMouseEvents
        public void OnMouseDown()
        {
            transform.localScale = transform.localScale + new Vector3(0.15f, 0, 0.15f);
            outline.enabled = true;
            PointerDownOnBar(bar);
            Debug.Log(bar.name);
            // int temp_id=0;
            // string temp_id_string="";
            // for(int i=2;i<bar.name.Length;i++){
            //     temp_id_string+=bar.name[i];
            // }
            // temp_id=int.Parse(temp_id_string);
            // Debug.Log(temp_id);

            // GameObject d_holder= GameObject.FindGameObjectWithTag("DataHolder");
            // string date= d_holder.GetComponent<dataholder>().data_list[temp_id].date;
            // Debug.Log(date);



            // TextAsset covidData = Resources.Load<TextAsset>("Egy-COVID-19");
            // string[] data = covidData.text.Split(new char[] { '\n' });
            // string[] row = data[].Split(new char[] { ',' });



        }
        public void OnMouseUp()
        {
            transform.localScale = barScale;
            outline.enabled = false;
            PointerUpOnBar(bar);
        }
        public void OnMouseEnter()
        {

            transform.localScale = transform.localScale + new Vector3(0.15f, 0, 0.15f);
            PointerEnterOnBar(bar);
            // outline.enabled = true;

        }
        public void OnMouseExit()
        {
            transform.localScale = barScale;
            outline.enabled = false;
            PointerExitOnBar(bar);
        }
        #endregion

        #endregion
    }
}
