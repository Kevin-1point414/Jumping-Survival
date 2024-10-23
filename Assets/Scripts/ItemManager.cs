using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static int numberOfExplosives = 0;
    public GameObject display;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && gameObject.name == "Explosive Item")
        {
            numberOfExplosives++;
            display.GetComponent<TextMeshProUGUI>().text = "Explosives: " + 
                numberOfExplosives;
            Destroy(gameObject);
        }
    }
}
