using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chosetarg : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("end")) { panel.SetActive(true); }
        //GetComponent<Renderer>().material.shader = Shader.Find("Models/Materials/FrontTex1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void end_panel_close() { PlayerPrefs.DeleteKey("end"); panel.SetActive(false); }
}
