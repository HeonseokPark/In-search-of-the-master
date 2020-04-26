using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 0.8f;
    public float scoreNum = 0;
    public Text score;

    void Update()
    {
        Vector3 movement = new Vector3(0, 0, Input.GetAxis("Vertical"));

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -speed, 0);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, speed, 0);

        score.text = $"{scoreNum}";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            scoreNum += 1;
        }
    }
}
