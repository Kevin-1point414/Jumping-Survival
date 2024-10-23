using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerGun : MonoBehaviour
{
    private new GameObject camera;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private GameObject explosiveDisplay;
    [SerializeField] private float explosiveSpeed;
    [SerializeField] float radius;
    private float score;
    [SerializeField] private float chanceOfEnemyDropExplosive;
    [SerializeField] private GameObject explosiveItemPrefab;
    [SerializeField] private GameObject explosivePrefab;

    void Start()
    {
        score = 0;
        camera = Camera.main.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.transform.position,
                camera.transform.rotation * Vector3.forward, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("DestroyedByGun"))
                {
                    if (Random.Range(0.0f, 1.0f) < chanceOfEnemyDropExplosive)
                    {
                        GameObject newExplosive = Instantiate(explosiveItemPrefab,
                            hit.transform.position, Quaternion.identity);
                        newExplosive.name = explosiveItemPrefab.name;
                        newExplosive.GetComponent<ItemManager>().display = explosiveDisplay;
                    }
                    score++;
                    scoreDisplay.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && ItemManager.numberOfExplosives > 0)
        {
            Physics.Raycast(camera.transform.position,
                camera.transform.rotation * Vector3.forward, out RaycastHit hit);
            Collider[] hitColliders = Physics.OverlapSphere(hit.point, radius);
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.GetComponent<EnemyAI>() != null)
                {
                    score++;
                    scoreDisplay.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
                    Destroy(collider.gameObject);
                }
            }
            ItemManager.numberOfExplosives--;
            explosiveDisplay.GetComponent<TextMeshProUGUI>().text = "Explosives: "
                + ItemManager.numberOfExplosives;
        }
    }
}
