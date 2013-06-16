using UnityEngine;
using System.Collections;

public class UI_controller : MonoBehaviour {
    //���d�B��O�B�Ѽƪ��ƭ�
    public static int iBarG_width = 300, iBarR_width = 300, iDayPast = 0;   
    //���{�ơB��O�ӷl�p��-->�qplayer_controller�̭��֥[(���ʮ�)�B���d�ӷl-->�Y�쳽���@�I�I
    public static float mileage = 0.0f, strengthDecay = 0.0f, healthDecay = 0.0f;
    public GUISkin GUISkin_t;

	// Use this for initialization
	void Start () {
        
	}
	
    // Update is called once per frame
	void Update () {
        iDayPast = DayCounter(mileage); //�p��Ѽ�(�̲��ʨ��{�W�[)
        iBarR_width = 300 - StrengthBarCounter(strengthDecay);  //��O�ӷl(�e�i��h�����h�B���k���ʸ���)
        iBarG_width = 300 - (int)healthDecay;  //���d�ӷl
        if (iBarR_width > 300) iBarR_width = 300;
        if (iBarG_width > 300) iBarG_width = 300;
        //����������
        GameObject.Find("GUI green bar").GetComponent<GUITexture>().pixelInset = new Rect(150, -40, iBarG_width, 20);
        GameObject.Find("GUI red bar").GetComponent<GUITexture>().pixelInset = new Rect(150, -60, iBarR_width, 20);
        GameObject.Find("GUI Text_day_num").GetComponent<GUIText>().text = string.Format("{0:D4}",iDayPast).ToString();
	}
    int DayCounter(float value) {
        return (int)value / 10; //�Y�ƥi�H�A�]�w
    }
    int StrengthBarCounter(float value)
    {
        return (int)value / 2;  //�Y�ƥi�H�A�]�w
    }

}
