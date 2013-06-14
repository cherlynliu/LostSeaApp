using UnityEngine;
using System.Collections;

public class boxController : MonoBehaviour {
    public static int[] objectsInBox = new int[3]{-1,-1,-1};    //紀錄增加各種物資的開關，-1等同於狀態歸零
    public static int[] objectsInBag = new int[3];  //紀錄包包裡擁有的物資
    public static bool isShowBox = false;   //是否顯示包包內容物

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (objectsInBox[0] >= 0)
        {
            if (objectsInBox[0] == 0) { print("got food*1"); objectsInBag[0] += 1; }
            if (objectsInBox[0] == 1) { print("got bottle*1"); objectsInBag[1] += 1; }
            if (objectsInBox[0] == 2) { print("got bottle with message*1"); objectsInBag[2] += 1; }
            if (objectsInBox[0] == 3) { print("got nothing"); }
            objectsInBox[0] = -1;
        }
        if (isShowBox) GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = true;   //開啟包包
        else GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = false;
	}
}
