using UnityEngine;
using System.Collections;

public class btnController : MonoBehaviour {
    public GUISkin skin;
    Rect btn_rect = new Rect(0, 0, 100, 100);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnGUI()
    {
        GUI.skin = skin;
        if (GUI.Button(btn_rect, "����]�]"))    //�]�]���s���U��true
        {
            //print("box :  you have food*" + boxController.objectsInBag[0] + ", bottle*" + boxController.objectsInBag[1] + ", bottle with message*" + boxController.objectsInBag[2]);
            boxController.isShowBox = !boxController.isShowBox; //������ܥ]�]���e�����}��
        }
    }
}
