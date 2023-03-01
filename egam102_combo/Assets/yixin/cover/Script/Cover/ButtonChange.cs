using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public ControlArrow contArrowScr;
    public int objNum;
    private float timer;
    private bool isPress;
    //public GameObject thisObj;
    // Start is called before the first frame update
    void Start()
    {
        StaticValue.isWin = false;
        contArrowScr= GameObject.FindGameObjectWithTag("Arrow").GetComponent<ControlArrow>();
    }

    // Update is called once per frame
    void Update()
    {
        JudgeNumber();
    }

    void JudgeNumber()
    {
        if (contArrowScr.array[contArrowScr.arrowNumberRow,contArrowScr.arrowNumberCol] == objNum&&Input.GetKeyDown(KeyCode.Space)&&!isPress) 
        {
            isPress=true;
            gameObject.transform.position -= new Vector3(0, 0.2f, 0);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1);

        }
        if (isPress)
        {
             timer += Time.deltaTime;
        }
         if (timer > 0.1f&& contArrowScr.array[contArrowScr.arrowNumberRow, contArrowScr.arrowNumberCol] == objNum)
         {     
            gameObject.transform.position += new Vector3(0, 0.2f, 0);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            isPress=false;
            timer = 0;
         }
        //if(contArrowScr.array[contArrowScr.arrowNumberRow, contArrowScr.arrowNumberCol] == objNum && Input.GetKeyUp(KeyCode.Space))
        //{
        //    gameObject.transform.position += new Vector3(0, 0.2f, 0);
        //    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        //}
    }
}
