using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArrow : MonoBehaviour
{
    public GameObject background;
    public Transform trans;
    public SpriteRenderer spriteCom;
    public Sprite[] sprite;
    public int[] numberArray;
    public int[,] array;
    public int arrowNumberRow;
    public int arrowNumberCol;
    public int arrowIndex;
    private int counter;

    public string spriteName;

    public float pressDis;
    public float timer;
    public float moveDistanceX;
    public float moveDistanceY;

    public EgamMicrogameInstance microgameInstance;
    // Start is called before the first frame update
    void Start()
    {

        microgameInstance = GameObject.FindObjectOfType<EgamMicrogameInstance>();
        sprite= Resources.LoadAll<Sprite>("yixin/key3");

        trans = gameObject.GetComponent<Transform>();
        spriteCom = GameObject.FindGameObjectWithTag("ArrowNumber").GetComponent<SpriteRenderer>();
        arrowNumberRow = 0;
        numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        array = new int[,]
        {
            {0,1,2,3,4,5,6,7,8,9 },
            {10,11,12,13,14,15,16,17,18,19 },
            {20,21,22,23,24,25,26,27,28,29},
            {30,31,32,33,34,35,36,37,38,39 }
        };
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!StaticValue.isWin)
        {
            ControlMove();
            ShowSprite();
            PressKey();
        }

    }

    void ShowSprite()
    {
        spriteCom.sprite = sprite[array[arrowNumberRow,arrowNumberCol]];
    }
    void PressKey()
    {
        if(Input.GetKeyDown(KeyCode.Space)/*&&counter==0*/&&!StaticValue.isPress)
        {
            //counter++;
            trans.position -= new Vector3(0f, pressDis, 0f);
            
            StaticValue.isPress = true;
            if (array[arrowNumberRow,arrowNumberCol]==StaticValue.randomNumber)
            {
                background.GetComponent<SpriteRenderer>().color = new Color(1, 0.95f, 0.05f, 1);
                microgameInstance.WinGame();
                counter=1;
            }
        }
        if(StaticValue.isPress)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.1f)
        {
            trans.position += new Vector3(0f, pressDis, 0f);
            StaticValue.isPress = false;
            if(counter==1)
            {
                StaticValue.isWin = true;
            }
            timer= 0;
        }
        //if(Input.GetKeyUp(KeyCode.Space) )
        //{
        //    counter = 0;
        //    StaticValue.isPress = false;
        //    trans.position+= new Vector3(0f, pressDis, 0f);
        //}
    }

    //void Timer()
    //{
    //    if(StaticValue.isPress == true)
    //    {
    //        timer += Time.deltaTime;
    //        if (timer > 1f)
    //        {
    //            isPress
    //        }
    //    }
    //}
    void ControlMove()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(arrowNumberRow>0)
            {
                arrowNumberRow -= 1;
                trans.position += new Vector3 (-moveDistanceX/2,moveDistanceY,0);
            }
            else
            {
                arrowNumberRow = 0;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(arrowNumberRow<3)
            {
                arrowNumberRow+= 1;
                trans.position -= new Vector3(-moveDistanceX/2, moveDistanceY, 0);
            }
            else
            {
                arrowNumberRow = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(arrowNumberCol>0)
            {
                arrowNumberCol -= 1;
                trans.position-=new Vector3(moveDistanceX,0,0);
            }
            else
            {
                arrowNumberCol = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrowNumberCol < 9)
            {
                arrowNumberCol+= 1;
                trans.position += new Vector3(moveDistanceX, 0, 0);
            }
            else
            {
                arrowNumberCol= 9;
            }
        }
    }
}
