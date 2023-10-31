using UnityEngine;

public class goalTrigger : MonoBehaviour
{
    bool goalObjectInPlace;
    private void Awake()
    {
        goalObjectInPlace = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal Object"))
        {
            goalObjectInPlace = true;
        }
    }
}