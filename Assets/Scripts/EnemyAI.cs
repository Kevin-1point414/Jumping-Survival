using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private new Rigidbody rigidbody;
    [SerializeField] private float speed;
    GameObject player;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Capsule");
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.Normalize(player.transform.position - transform.position) * speed 
            * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Playground");
        }
    }
}
