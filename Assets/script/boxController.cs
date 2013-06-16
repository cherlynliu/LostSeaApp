using UnityEngine;
using System.Collections;

public class boxController : MonoBehaviour {
    public static int objectsInBox;    //�����W�[�U�ت��ꪺ�}���A-1���P�󪬺A�k�s
    public static int[] m_objectsInBag = new int[9];  //�����]�]�֦̾�������_�K�ϥ�
    public static bool isShowBox = false;   //�O�_��ܥ]�]���e��
    public Material[] mat_things;    //�]�]���e��������
    //0:�w�]�c�l 1:���Y 2:�� 3:�� 4:�~���H 5:�p�q

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (objectsInBox > 0)
        {
            if (objectsInBox == 1) { print("got a food can");fillBagCheck(1); }   //1:����(���Y)
            if (objectsInBox == 2) { print("got a fish"); fillBagCheck(2); } //2:��
            if (objectsInBox == 3) { print("got a bottle of water"); fillBagCheck(3); }    //3:��
            if (objectsInBox == 4) { print("got bottle with message"); fillBagCheck(4); }    //4:�~���H
            //if (objectsInBox == 5) { print("bump into a island"); fillBagCheck(5); }    //5:�p�q
            objectsInBox = -1;
        }
        if (isShowBox) GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = true;   //�}�ҥ]�]
        else GameObject.Find("Camera_BOX").gameObject.GetComponent<Camera>().enabled = false;

        thingsInBagSetting();

        //��L�Ʀr1�A�ϥΪ���
        if (Input.GetKey(KeyCode.Keypad1)) useThingsInBag(0);
        if (Input.GetKey(KeyCode.Keypad2)) useThingsInBag(1);
        if (Input.GetKey(KeyCode.Keypad3)) useThingsInBag(2);
        if (Input.GetKey(KeyCode.Keypad4)) useThingsInBag(3);
        if (Input.GetKey(KeyCode.Keypad5)) useThingsInBag(4);
        if (Input.GetKey(KeyCode.Keypad6)) useThingsInBag(5);
        if (Input.GetKey(KeyCode.Keypad7)) useThingsInBag(6);
        if (Input.GetKey(KeyCode.Keypad8)) useThingsInBag(7);
        if (Input.GetKey(KeyCode.Keypad9)) useThingsInBag(8);
	}

    void useThingsInBag(int value)
    {
        if (m_objectsInBag[value] == 1)
        {
            UI_controller.strengthDecay -= 100;  //�ϥ�³�����Y�A�W�[��O100
        }
        if (m_objectsInBag[value] == 2)
        {
            UI_controller.strengthDecay -= 50;  //�ϥγ��A�W�[��O50�A���d-10
            UI_controller.healthDecay += 10;
        }
        if (m_objectsInBag[value] == 3)
        {
            UI_controller.strengthDecay -= 25;  //�ϥΤ��A�W�[��O25�A���d+10
            UI_controller.healthDecay -= 10;
        }
        m_objectsInBag[value] = 0;
    }
    //�ˬd�]�]���L�Ŷ��A�ðO���U�ӡA�h�����z(�ߤ��_��)
    void fillBagCheck(int value)
    {
        for (int i = 0; i < 9; i++)
        {
            if (m_objectsInBag[i] == 0)
            {
                m_objectsInBag[i] = value;
                break;
            }
        }
    }
    //�t�m�����]�]�̡A����
    void thingsInBagSetting()
    {
        GameObject.Find("Bag Plane 7").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[6]];
        GameObject.Find("Bag Plane 8").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[7]];
        GameObject.Find("Bag Plane 9").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[8]];
        GameObject.Find("Bag Plane 4").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[3]];
        GameObject.Find("Bag Plane 5").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[4]];
        GameObject.Find("Bag Plane 6").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[5]];
        GameObject.Find("Bag Plane 1").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[0]];
        GameObject.Find("Bag Plane 2").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[1]];
        GameObject.Find("Bag Plane 3").gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat_things[m_objectsInBag[2]];
    }
}
