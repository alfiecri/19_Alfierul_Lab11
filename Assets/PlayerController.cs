using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public GameObject healthText;
    public GameObject Character;

    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<Text>().text = "Health: " + health;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsWalkBool", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("IsWalkBool", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("IsWalkBool", true);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("IsWalkBool", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsWalkBool", true);

        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("IsWalkBool", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("IsWalkBool", true);

        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("IsWalkBool", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("AttackTrigger");
        }

        if (health <= 0)
        {
            animator.SetTrigger("DeadTrigger");
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health: " + health;

            if (health < 1)
            {
                healthText.GetComponent<Text>().text = "Health: " + 0;
            }
        }
    }
}
