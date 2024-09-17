using UnityEngine;

public class MovementTester : MonoBehaviour
{
    private Collision currColl;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            foreach(var cont in currColl.contacts) {
                Debug.Log($"� {cont.thisCollider.name} �� ������� �" +
                    $" {cont.otherCollider.name} � ����� {cont.point}");
            
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        currColl = collision;
    }
}
