using UnityEngine;

public class MovementTester : MonoBehaviour
{
    private Collision currColl;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            foreach(var cont in currColl.contacts) {
                Debug.Log($"я {cont.thisCollider.name} ща контачу с" +
                    $" {cont.otherCollider.name} в точке {cont.point}");
            
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        currColl = collision;
    }
}
