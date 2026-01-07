using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;

    private Rigidbody rb;
    private PooledObject pooledObject;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pooledObject = GetComponent<PooledObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        rb.linearVelocity = transform.forward * speed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
