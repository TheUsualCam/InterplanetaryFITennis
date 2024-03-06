using UnityEngine;

public class DestroyObjectsOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.gameObject.tag != "Controller")
        {
            Destroy(other.attachedRigidbody.gameObject);
        }
        else if(other.gameObject.tag != "Controller")
        {
            Destroy(other.gameObject);
        }
    }
}
