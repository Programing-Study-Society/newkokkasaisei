using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject targetPrefab;

    public void RotateObject90Degrees()
    {

        // �I�u�W�F�N�g�̒��S���擾
        Vector3 center = targetPrefab.GetComponent<Renderer>().bounds.center;
        Vector3 rotate = targetPrefab.GetComponent<Transform>().localEulerAngles;
        if (rotate.z == -90)
        {
            // �I�u�W�F�N�g��Z���𒆐S��90�x��]������
            targetPrefab.transform.RotateAround(center, Vector3.forward, 90f);
        }
        else
        {
            // �I�u�W�F�N�g�𒆐S���Y����90�x��]������
            targetPrefab.transform.RotateAround(center, Vector3.up, 90f);
        }
    }
}
