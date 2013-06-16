using UnityEngine;
using System.Collections;

public class boxController : MonoBehaviour {
    public static int objectsInBox;    //紀錄增加各種物資的開關，-1等同於狀態歸零
    public static int[] m_objectsInBag = new int[9];  //紀錄包包裡擁有的物資_貼圖用
    public static bool isShowBox = false;   //是否顯示包包內容物
    public Material[] mat_things;    //包包內容物的材質
    //0:預設箱子 1:罐頭 2:魚 3:水 4:瓶中信 5:小島

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (objectsInBox > 0)
        {
            if (objectsInBox == 1) { print("got a food can");fillBagCheck(1); }   //1:食物(罐頭)
            if (objectsInBox == 2) { print("got a fish"); fillBagCheck(2); } //2:魚
            if (objectsInBox == 3) { print("got a bottle of water"); fillBagCheck(3); }    //3:水
            if (objectsInBox == 4) { print("got bottle with message"); fillBagCheck(4); }    //4:瓶中信
            //if (objectsInBox == 5) { print("bump into a island"); fillBagCheck(5); }    //5:小島
            objectsInBox = -1;
        }
        if (isShowBox) GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = true;   //開啟包包
        else GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = false;

        thingsInBagSetting();

        //鍵盤數字1，使用物資
        if (Input.GetKey(KeyCode.Keypad1)) useThingsInBag(0);
        if (Input.GetKey(KeyCode.Keypad2)) useThingsInBag(1);
        if (Input.GetKey(KeyCode.Keypad3)) useThingsInBag(2);
        if (Input.GetKey(KeyCode.Keypad4)) useThingsInBag(3);
        if (Input.GetKey(KeyCode.Keypad5)) useThingsInBag(4);
        if (Input.GetKey(KeyCode.Keypad6)) useThingsInBag(5);
        if (Input.GetKey(KeyCode.Keypad7)) useThingsInBag(6);
        if (Input.GetKey(KeyCode.Keypad8)) useThingsInBag(7);
        if (Input.GetKey(KeyCode.Keypad9)) useThingsInBag(8);
	}

    void useThingsInBag(int value)
    {
        if (m_objectsInBag[value] == 1)
        {
            UI_controller.strengthDecay -= 100;  //使用糧食罐頭，增加體力100
        }
        if (m_objectsInBag[value] == 2)
        {
            UI_controller.strengthDecay -= 50;  //使用魚，增加體力50，健康-10
            UI_controller.healthDecay += 10;
        }
        if (m_objectsInBag[value] == 3)
        {
            UI_controller.strengthDecay -= 25;  //使用水，增加體力25，健康+10
            UI_controller.healthDecay -= 10;
        }
        m_objectsInBag[value] = 0;
    }
    //檢查包包有無空間，並記錄下來，多的不理(撿不起來)
    void fillBagCheck(int value)
    {
        for (int i = 0; i < 9; i++)
        {
            if (m_objectsInBag[i] == 0)
            {
                m_objectsInBag[i] = value;
                break;
            }
        }
    }
    //配置物資到包包裡，換圖
    void thingsInBagSetting()
    {
        GameObject.Find("Bag Plane 7").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[6]];
        GameObject.Find("Bag Plane 8").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[7]];
        GameObject.Find("Bag Plane 9").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[8]];
        GameObject.Find("Bag Plane 4").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[3]];
        GameObject.Find("Bag Plane 5").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[4]];
        GameObject.Find("Bag Plane 6").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[5]];
        GameObject.Find("Bag Plane 1").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[0]];
        GameObject.Find("Bag Plane 2").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[1]];
        GameObject.Find("Bag Plane 3").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[2]];
    }
}
