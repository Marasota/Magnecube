using UnityEngine;

public static class MovementChecker
{ 
    static public  bool CanMove(Collider boxCollider, LayerMask layerMask)
    {
        Vector3 boxCenter = boxCollider.bounds.center;
        Vector3 boxSize = boxCollider.bounds.size;
        

        Collider[] hitColliders = Physics.OverlapBox(boxCenter, boxSize / 2, boxCollider.transform.rotation, layerMask);

        return hitColliders.Length == 0;
    }
}
