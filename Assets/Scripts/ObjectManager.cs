using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // you mlikshake is cute 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area.");
            // You can add additional logic here, such as activating an object, starting a cutscene, etc.
        }
    }
}