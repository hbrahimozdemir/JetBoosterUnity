using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is Launch Pad");
                break;
            case "Finish":
                Debug.Log("This is Landing Pad");
                break;
            case "Fuel":
                Debug.Log("This is Fuel");
                break;
            default:
                Debug.Log("KA-BOOOM");
                break;
        }
    }
}
