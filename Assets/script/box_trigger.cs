using UnityEngine;
using System.Collections;

public class box_trigger : MonoBehaviour {
    
    private float shakeValue = 0f;

    //GameObject box
    bool OnTriggerEnter(Collider col)
    {
        boxController.objectsInBox = this.GetComponent<boxChanger>().thingNumber; //���w����s��(boxChanger�H������)
        
        if (boxController.objectsInBox > 3) Destroy(this.gameObject, 0.25f);
        else this.GetComponent<boxChanger>().isGetThis = true;

        BoxCreator.isAddBox = true;
        return false;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Shaking();
	}

    private void Shaking()
    {
        //�W�U�̰�
        if (Time.time % 4.8f > 2.4f)
            this.transform.Rotate(new Vector3(-1, 0, 0), shakeValue * Time.deltaTime, Space.Self);
        else
            this.transform.Rotate(new Vector3(1, 0, 0), shakeValue * Time.deltaTime, Space.Self);

        //���k�̰�
        if (Time.time % 3.2f > 1.6f)
            this.transform.Rotate(new Vector3(0, 0, 1), shakeValue * Time.deltaTime, Space.Self);
        else
            this.transform.Rotate(new Vector3(0, 0, -1), shakeValue * Time.deltaTime, Space.Self);

        //�̰ʼƭ�
        shakeValue += Mathf.Cos(Mathf.Repeat(Time.time, 10) / 200f * Mathf.PI) * Time.deltaTime;// *Mathf.Repeat(0, 10);
        if (shakeValue > 1) shakeValue = 0;
        //print(shakeValue.ToString());
    }
}
