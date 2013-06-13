using UnityEngine;
using System.Collections;

public class btnController : MonoBehaviour {
    public GUISkin skin;
    Rect btn_rect = new Rect(0, 0, 100, 100);
    //Rect bag_rect = new Rect(0, 100, 256, 256);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnGUI()
    {
        GUI.skin = skin;
        //GUI.Label(bag_rect, skin.label.normal.background);
        if (GUI.Button(btn_rect, "box"))    //包包按鈕按下為true
        {
            print("box :  you have food*" + boxController.objectsInBag[0] + ", bottle*" + boxController.objectsInBag[1] + ", bottle with message*" + boxController.objectsInBag[2]);
            boxController.isShowBox = true; //開啟顯示包包內容物的開關為true
            //GUI.Label(bag_rect, skin.label.normal.background);
        }
    }
}
