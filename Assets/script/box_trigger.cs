using UnityEngine;
using System.Collections;

public class box_trigger : MonoBehaviour {
    //GameObject box
    bool OnTriggerEnter(Collider col)
    {
        boxController.objectsInBox[0] = Random.Range(0, 4);
        Destroy(this.gameObject, 0.25f);
        //Instantiate((object)GameObject.Find("box"), new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)));
        return false;
    }
	// Use this for initialization
	void Start () {
        //Debug.Log(this.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
