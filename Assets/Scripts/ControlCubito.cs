using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubito : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Rigidbody2D cubitoRb;
    [SerializeField] private Color BaseRayo = Color.white;
    [SerializeField] private Color GolpearRayo = Color.blue;
    [SerializeField] private LayerMask Interaccion;
    void Start()
    {
        if (cubitoRb == null)
        {
            cubitoRb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float MoverX = Input.GetAxisRaw("Horizontal");
        float MoverY = Input.GetAxisRaw("Vertical");
        Vector2 direccion = new Vector2(MoverX, MoverY);
        cubitoRb.velocity = direccion * velocidad;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, direccion, 50f, Interaccion);
        if(raycastHit2D.collider != null)
        {
            Debug.DrawRay(transform.position, direccion * raycastHit2D.distance, GolpearRayo);
            Debug.Log(raycastHit2D.collider.gameObject.name);
            Debug.Log(raycastHit2D.collider.gameObject.transform.position);
            Debug.Log(raycastHit2D.collider.gameObject.tag);
        }
        else
        {
            Debug.DrawRay(transform.position, direccion * 50f, BaseRayo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shape"))
        {
            GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
        }
        else if (collision.gameObject.CompareTag("Color"))
        {
            GetComponent<SpriteRenderer>().color = collision.GetComponent<SpriteRenderer>().color;
        }
    }
}
