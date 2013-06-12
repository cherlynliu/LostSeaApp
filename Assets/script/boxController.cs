using UnityEngine;
using System.Collections;

public class boxController : MonoBehaviour {
    public static int[] objectsInBox = new int[3]{-1,-1,-1};
    public static int[] objectsInBag = new int[3];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //objectsInBag[0].transform = new Transform();
        if (objectsInBox[0] >= 0)
        {
            if (objectsInBox[0] == 0) { print("got food*1"); objectsInBag[0] += 1; }
            if (objectsInBox[0] == 1) { print("got bottle*1"); objectsInBag[1] += 1; }
            if (objectsInBox[0] == 2) { print("got bottle with message*1"); objectsInBag[2] += 1; }
            if (objectsInBox[0] == 3) { print("got nothing"); }
            objectsInBox[0] = -1;
        }
	}
}
