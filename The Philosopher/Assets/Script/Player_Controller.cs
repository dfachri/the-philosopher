using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody;
    public float kecepatan = 40f;
    public float moveX = 0f;
    private Vector3 zero = Vector3.zero;
    private bool HadapKanan = true;
    public float smoother = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal") * kecepatan;
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        Vector3 targetVelocity = new Vector2(moveX * 10f, rigidbody.velocity.y);
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref zero, smoother);
        if (moveX > 0 && !HadapKanan)
        {
            Flip();
        }
        else if (moveX < 0 && HadapKanan)
        {
            Flip();
        }
    }
    private void Flip() // Fungsi untuk membalikkan arah player
    {
        HadapKanan = !HadapKanan;
        Vector3 skala = transform.localScale;
        skala.x *= -1;
        transform.localScale = skala;
    }
}
