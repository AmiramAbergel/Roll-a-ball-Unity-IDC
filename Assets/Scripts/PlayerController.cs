using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] ParticleSystem PickUp = null;
	public float speed;
	public GameObject _pois;
	public Text countText;
	public Text winText;

	public GameObject _spawnBox;

	private float moveHorizontal;

	private float moveVertical;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        moveHorizontal = movementVector.x;
        moveVertical = movementVector.y;
    }

	void FixedUpdate()
	{
		
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(new Vector3(0, 20, 0) * speed);
        }

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
		
       // if (rb.position.y < -1f){
         //   FindObjectOfType<MenuController>().EndGame();
       // }
		
	}
	Vector3 RndPosInBox(){
		Vector3 newPos;
		newPos = new Vector3(Random.Range(-1f,1f)* _spawnBox.transform.localScale.x * .5f,.5f,Random.Range(-1f,1f)* _spawnBox.transform.localScale.z * .5f);
		return newPos;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			PickUp.Play();
			other.gameObject.transform.localPosition = RndPosInBox();
			count = count + 1;
			SetCountText();
		}
		else if (other.gameObject.CompareTag("Obst")){
            rb.AddForce(new Vector3(0, 50, 0) * speed);
        }
		else if (other.gameObject.CompareTag("Pois")){
			Debug.Log("Pois");
			if (_pois != null){
				Debug.Log("pois event");
				//_pois.Invoke();
			}
		}
	
	}

	void SetCountText()
	{
		countText.text = "Score: " + count.ToString();

		if (count >= 12) {
			winText.text = "You Win!";
		}
	}

}
