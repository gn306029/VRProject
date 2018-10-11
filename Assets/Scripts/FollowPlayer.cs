using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [Tooltip("Main Player")]
    public Transform player;
    [Tooltip("Character walk speed")]
    public float speed;
    [Tooltip("Min Distence")]
    public float minDistence;

    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        transform.LookAt(new Vector3(player.position.x , player.position.y , player.position.z));
        if (Vector3.Distance(transform.position , player.position) >= minDistence)
        {
            Vector3 direction = transform.forward * speed * Time.deltaTime;
            controller.Move(direction);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
	}
}
