using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // �� ī�޶�
    public GameObject top;
    // �÷��̾� �� ī�޶�
    public GameObject back;
    // �밢�� �� ī�޶�
    public GameObject diagonal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� 1�� Ű�� ������ �� 
        if(Input.GetKey(KeyCode.Alpha1))
        {
            // �÷��̾� �� ī�޶� �ѱ�
            top.SetActive(false);
            diagonal.SetActive(false);

            back.SetActive(true);
        }
        // ���� ���� 2�� Ű�� ������ �� 
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            diagonal.SetActive(false);
            back.SetActive(false);

            // �� ī�޶� �ѱ�
            top.SetActive(true);
        }
        // ���� ���� 3�� Ű�� ������ �� 
        else if(Input.GetKey(KeyCode.Alpha3))
        {
            top.SetActive(false);
            back.SetActive(false);

            // �밢�� �� ī�޶� �ѱ�
            diagonal.SetActive(true);
        }
    }
}
