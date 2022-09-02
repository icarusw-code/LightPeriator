using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // 위 카메라
    public GameObject top;
    // 플레이어 뒤 카메라
    public GameObject back;
    // 대각선 위 카메라
    public GameObject diagonal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 숫자 1번 키를 눌렀을 때 
        if(Input.GetKey(KeyCode.Alpha1))
        {
            // 플레이어 뒤 카메라 켜기
            top.SetActive(false);
            diagonal.SetActive(false);

            back.SetActive(true);
        }
        // 만약 숫자 2번 키를 눌렀을 때 
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            diagonal.SetActive(false);
            back.SetActive(false);

            // 위 카메라 켜기
            top.SetActive(true);
        }
        // 만약 숫자 3번 키를 눌렀을 때 
        else if(Input.GetKey(KeyCode.Alpha3))
        {
            top.SetActive(false);
            back.SetActive(false);

            // 대각선 위 카메라 켜기
            diagonal.SetActive(true);
        }
    }
}
