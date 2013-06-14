using UnityEngine;
using System.Collections;

public class BoxCreator : MonoBehaviour {
    public static bool isAddBox = false;
    public GameObject box_prefab;
    float randRange = 100f;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 30; i++) GameObject.Instantiate(box_prefab, new Vector3(Random.Range(-randRange, randRange), 0, Random.Range(-randRange, randRange)), new Quaternion(0, 0, 0, 1));
	}
	
	// Update is called once per frame
	void Update () {
        if (isAddBox)
        {
            GameObject.Instantiate(box_prefab, new Vector3(Random.Range(-randRange, randRange), 0, Random.Range(-randRange, randRange)), new Quaternion(0, 0, 0, 1));
            isAddBox = false;
        }
	}
}
