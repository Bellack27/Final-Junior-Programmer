using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected Rigidbody m_Rigidbody;
    public float m_Speed = 20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    protected void Update()
    {
        BulletMove();
    }

    protected void BulletMove()
    {
        m_Rigidbody.linearVelocity = transform.forward * m_Speed;
    }
}
