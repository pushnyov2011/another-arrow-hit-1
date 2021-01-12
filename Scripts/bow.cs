using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class bow : MonoBehaviour
{
    public float length;
    public float x1;
    public float x2;
    public float x3;
    public float y1;
    public float y2;
    public float y3;
    public float z1;
    public float z2;
    public float z3;



    public GameObject bowString;
    public List<Vector3> bowStringPosition;
    LineRenderer bowStringLinerenderer;
    public Vector3 stringPullout;
    public Vector3 stringRestPosition = new Vector3(-0.44f, -0.06f, 2f);

    // Start is called before the first frame update
    void Start()
    {

        bowStringLinerenderer = bowString.AddComponent<LineRenderer>();
        bowStringLinerenderer.SetVertexCount(3);
        bowStringLinerenderer.SetWidth(0.05F, 0.05F);
        bowStringLinerenderer.useWorldSpace = false;
        bowStringLinerenderer.material = Resources.Load("Materials/bowStringMaterial") as Material;
        bowStringPosition = new List<Vector3>();
        bowStringPosition.Add(new Vector3(-0.44f, 1.43f, 2f));
        bowStringPosition.Add(new Vector3(-0.44f, -0.06f, 2f));
        bowStringPosition.Add(new Vector3(-0.43f, -1.32f, 2f));
        bowStringLinerenderer.SetPosition(0, bowStringPosition[0]);
        bowStringLinerenderer.SetPosition(1, bowStringPosition[1]);
        bowStringLinerenderer.SetPosition(2, bowStringPosition[2]);
        //  arrowStartX = 0.7f;

        stringPullout = stringRestPosition;

    }

    // Update is called once per frame
    void Update()
    {
        prepareArrow();
        //bowStringLinerenderer = bowString.AddComponent<LineRenderer>();
        //bowStringLinerenderer.SetVertexCount(3);
        //bowStringLinerenderer.SetWidth(0.05F, 0.05F);
        //bowStringLinerenderer.useWorldSpace = false;
        //bowStringLinerenderer.material = Resources.Load("Materials/bowStringMaterial") as Material;
        //bowStringPosition = new List<Vector3>();
        //bowStringPosition.Add(new Vector3(x1, y1, z1));
        //bowStringPosition.Add(new Vector3(x2, y2, z2));
        //bowStringPosition.Add(new Vector3(x3, y3, z3));
        //bowStringLinerenderer.SetPosition(0, bowStringPosition[0]);
        //bowStringLinerenderer.SetPosition(1, bowStringPosition[1]);
        //bowStringLinerenderer.SetPosition(2, bowStringPosition[2]);
    }
    public void drawBowString()
    {
        bowStringLinerenderer = bowString.GetComponent<LineRenderer>();
        bowStringLinerenderer.SetPosition(0, bowStringPosition[0]);
        bowStringLinerenderer.SetPosition(1, stringPullout);
        bowStringLinerenderer.SetPosition(2, bowStringPosition[2]);
    }
    public void prepareArrow()
    {
        // get the touch point on the screen
        //mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(mouseRay1, out rayHit, 1000f) && arrowShot == false)

        // determine the position on the screen
        ////posX = this.rayHit.point.x;
        //posY = this.rayHit.point.y;
        // set the bows angle to the arrow
        //Vector2 mousePos = new Vector2(transform.position.x-posX,transform.position.y-posY);
        //float angleZ = Mathf.Atan2(mousePos.y,mousePos.x)*Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0,0,angleZ);
        // determine the arrow pullout
       
        length = Mathf.Clamp(length, 0, 1);
        // set the bowstrings line renderer
        stringPullout = new Vector3(-(0.44f + length), -0.06f, 2f);
        // set the arrows position
      //  Vector3 arrowPosition = arrow.transform.localPosition;
      ////  arrowPosition.x = (arrowStartX - length);
        //arrow.transform.localPosition = arrowPosition;

    }
}