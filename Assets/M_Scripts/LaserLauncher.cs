using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class LaserLauncher : MonoBehaviour
{
    [Header("Laser Info")]
    public float maxDistance = 500f;
    public float intensity = 10f;
    public int maxReflectionCount = 5;

    private List<Vector3> laserPointList = new List<Vector3>();

    LineRenderer laserEffect;

    void Start()
    {
        laserEffect = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // ������ ���� ����
        laserEffect.startWidth = intensity * 0.01f;

        laserPointList.Clear();

        Vector3 startPos = transform.position;
        Vector3 direction = transform.forward;
        float distance = maxDistance;

        laserPointList.Add(startPos);

        HitTest(startPos, direction, maxDistance, 0, LayerMask.NameToLayer("Mirror"));

        // �� ������ �ѹ��� �׸����� 
        laserEffect.SetPositions(laserPointList.ToArray());

    }

    private void HitTest(Vector3 startPos, Vector3 direction, float distance, int index, LayerMask reflectableLayer)
    {
        // ���� �ݻ� ����
        if (maxReflectionCount < index) return;

        RaycastHit hit;

        laserEffect.positionCount = index + 2;

        // ������, ����, hitInfo, 
        if (Physics.Raycast(startPos, direction, out hit, distance))
        {
            if (hit.transform.gameObject.GetComponentInChildren<Light>())
            {
                hit.transform.gameObject.GetComponentInChildren<Light>().enabled = true;
                
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("End"))
                {
                    Invoke("scenechange", 1);
                }
                
            }
            

            // �浹 ����
            laserPointList.Add(hit.point);

            if (hit.transform.gameObject.GetComponent<PrismLaserChecker>() != null)
            {
                hit.transform.gameObject.GetComponent<PrismLaserChecker>().isHit = true;
            }

            // �ݻ纤�� ���ϱ�
            Vector3 reflectDir = Vector3.Reflect(direction, hit.normal);

            // �ݻ� ������ ������Ʈ
            if(reflectableLayer == hit.collider.gameObject.layer)
            {
                // ���
                HitTest(hit.point, reflectDir, distance, index + 1, reflectableLayer);
            }
        }
        // �浹 ���ϸ�
        else
        {
            laserPointList.Add(startPos + direction * distance);

        }

    }

    void scenechange()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
