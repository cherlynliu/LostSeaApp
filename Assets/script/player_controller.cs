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
        Vector3 v1 = new Vector3(-playerPos.x / playerPos.x, 0, -playerPos.z / playerPos.z);    //v1為單位向量

        //健康和體力在容許值之內(>0)才能移動
        //計算是否在海面範圍內，true才能進行移動
        if(UI_controller.iBarG_width > 0 && UI_controller.iBarR_width > 0)
            if (Mathf.Sqrt(Mathf.Pow(playerPos.x, 2f) + Mathf.Pow(playerPos.z, 2f)) < 125)
                moveDetect();
        else BoatAndPlayer.transform.Translate(v1 * Time.deltaTime, Space.World);

        //UpdatePlayer(touchDetector.enTouchType);  //平板用，沒寫好
        //羅盤介面的旋轉
        GameObject.Find("Plane_compass").transform.position = new Vector3(BoatAndPlayer.transform.position.x, 20, BoatAndPlayer.transform.position.z);
        Shaking();
	}
    //偵測移動(鍵盤WASD)
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
        //上下晃動
        if (Time.time % 2.4f > 1.2f)
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(-1, 0, 0), shakeValue * Time.deltaTime, Space.Self);
        else
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(1, 0, 0), shakeValue * Time.deltaTime, Space.Self);
        
        //左右晃動
        if (Time.time % 3.2f > 1.6f)
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(0, 0, 1), shakeValue * Time.deltaTime, Space.Self);
        else
            GameObject.Find("Main Camera").gameObject.transform.Rotate(new Vector3(0, 0, -1), shakeValue * Time.deltaTime, Space.Self);
        
        //晃動數值
        shakeValue += Mathf.Cos(Mathf.Repeat(Time.time, 10) / 200f * Mathf.PI) * Time.deltaTime;// *Mathf.Repeat(0, 10);
        if (shakeValue > 1) shakeValue = 0;
        //print(shakeValue.ToString());
    }
}
