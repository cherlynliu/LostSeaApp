using UnityEngine;
using System.Collections;

public class boxController : MonoBehaviour {
    public static int[] objectsInBox = new int[3]{-1,-1,-1};    //�����W�[�U�ت��ꪺ�}���A-1���P�󪬺A�k�s
    public static int[] objectsInBag = new int[3];  //�����]�]�֦̾�������
    public static bool isShowBox = false;   //�O�_��ܥ]�]���e��

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
        if (isShowBox) GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = true;   //�}�ҥ]�]
        else GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = false;
	}
}
