using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
    public Transform BoatAndPlayer;
    public float shakeValue = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = GameObject.Find("Plane_compass").transform.position;
        Vector3 v1 = new Vector3(-playerPos.x / playerPos.x, 0, -playerPos.z / playerPos.z);    //v1�����V�q

        //���d�M��O�b�e�\�Ȥ���(>0)�~�ಾ��
        //�p��O�_�b�����d�򤺡Atrue�~��i�沾��
        if(UI_controller.iBarG_width > 0 && UI_controller.iBarR_width > 0)
            if (Mathf.Sqrt(Mathf.Pow(playerPos.x, 2f) + Mathf.Pow(playerPos.z, 2f)) < 125)
                moveDetect();
        else BoatAndPlayer.transform.Translate(v1 * Time.deltaTime, Space.World);

        //UpdatePlayer(touchDetector.enTouchType);  //���O�ΡA�S�g�n
        //ù�L����������
        GameObject.Find("Plane_compass").transform.position = new Vector3(BoatAndPlayer.transform.position.x, 20, BoatAndPlayer.transform.position.z);
        Shaking();
	}
    //��������(��LWASD)
    private void moveDetect() {
        if (Input.GetKey(KeyCode.S))
        {
            BoatAndPlayer.transform.Translate(0, 0, -5f * Time.deltaTime);
            UI_controller.mileage += 5f * Time.deltaTime;
            UI_controller.strengthDecay += 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime);
            UI_controller.mileage += 7.5f * Time.deltaTime;
            UI_controller.strengthDecay += 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0);
            UI_controller.strengthDecay += 2.5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0);
            UI_controller.strengthDecay += 2.5f * Time.deltaTime;
        }
    }

    private void UpdatePlayer()//enTouchType T)
    {
        /*if (T == touchDetector.enTouchType.SwipeDown) { BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeUp) { BoatAndPlayer.transform.Translate(0, 0, -5 * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeLeft) { BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0); }
        if (T == touchDetector.enTouchType.SwipeRight) { BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0); }*/
    }

    private void Shaking() 
    {
        //�W�U�̰�
        if (Time.time % 2.4f > 1.2f)
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(-1, 0, 0), shakeValue * Time.deltaTime, Space.Self);
        else
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(1, 0, 0), shakeValue * Time.deltaTime, Space.Self);
        
        //���k�̰�
        if (Time.time % 3.2f > 1.6f)
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(0, 0, 1), shakeValue * Time.deltaTime, Space.Self);
        else
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(0, 0, -1), shakeValue * Time.deltaTime, Space.Self);
        
        //�̰ʼƭ�
        shakeValue += Mathf.Cos(Mathf.Repeat(Time.time, 10) / 200f * Mathf.PI) * Time.deltaTime;// *Mathf.Repeat(0, 10);
        if (shakeValue > 1) shakeValue = 0;
        //print(shakeValue.ToString());
    }
}
