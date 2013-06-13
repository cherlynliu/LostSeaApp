using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
    public Transform BoatAndPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = GameObject.Find("Plane_compass").transform.position;
        Vector3 v1 = new Vector3(-playerPos.x / playerPos.x, 0, -playerPos.z / playerPos.z);
        if (Mathf.Sqrt(Mathf.Pow(playerPos.x, 2f) + Mathf.Pow(playerPos.z, 2f)) < 125) moveDetect();
        else BoatAndPlayer.transform.Translate(v1 * Time.deltaTime, Space.World);
        //UpdatePlayer(touchDetector.enTouchType);
        GameObject.Find("Plane_compass").transform.position = new Vector3(BoatAndPlayer.transform.position.x, 20, BoatAndPlayer.transform.position.z);

	}
    private void moveDetect() {
        if (Input.GetKey(KeyCode.S)) BoatAndPlayer.transform.Translate(0, 0, -5 * Time.deltaTime);
        if (Input.GetKey(KeyCode.W)) BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D)) BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0);
    }

    private void UpdatePlayer()//enTouchType T)
    {
        /*if (T == touchDetector.enTouchType.SwipeDown) { BoatAndPlayer.transform.Translate(0, 0, 7.5f * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeUp) { BoatAndPlayer.transform.Translate(0, 0, -5 * Time.deltaTime); }
        if (T == touchDetector.enTouchType.SwipeLeft) { BoatAndPlayer.transform.Rotate(0, -30 * Time.deltaTime, 0); }
        if (T == touchDetector.enTouchType.SwipeRight) { BoatAndPlayer.transform.Rotate(0, 30 * Time.deltaTime, 0); }*/
    }
}
