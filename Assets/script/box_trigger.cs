using UnityEngine;
using System.Collections;

public class box_trigger : MonoBehaviour {
    int material_Kind = 4;  //物資種類數量
    //GameObject box
    bool OnTriggerEnter(Collider col)
    {
        boxController.objectsInBox[0] = Random.Range(0, material_Kind); //隨機產生一種物資
        Destroy(this.gameObject, 0.25f);
        return false;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
