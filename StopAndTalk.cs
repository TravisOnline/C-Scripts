using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopAndTalk : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        StartCoroutine("StartWalking");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Wander>().enabled = false;
            text.SetActive(true);
            gameObject.GetComponent<Animator>().Play("Armature|Stand");
            if (Input.GetButtonDown("Fire2"))
            {
                text.GetComponent<TextMeshProUGUI>().text = "Ha ha this place makes me feel weird, Bobby.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.GetComponent<TextMeshProUGUI>().text = "Press Action to Talk";
            text.SetActive(false);
            gameObject.GetComponent<Animator>().Play("Armature|Walk");
            gameObject.GetComponent<Wander>().enabled = true;
        }
    }

    //walk for 3-7 seconds
    IEnumerator StartWalking()
    {
        if(gameObject.GetComponent<Wander>().enabled == false)
        {
            gameObject.GetComponent<Wander>().enabled = true;
        }
        gameObject.GetComponent<Animator>().Play("Armature|Walk");
        yield return new WaitForSeconds(Random.Range(3, 7));
        StartCoroutine("StopWalking");
        //stop walking
    }

    IEnumerator StopWalking()
    {
        if (gameObject.GetComponent<Wander>().enabled == true)
        {
            gameObject.GetComponent<Wander>().enabled = false;
        }
        //stop walking for 1-5 seconds
        gameObject.GetComponent<Animator>().Play("Armature|Stand");
        yield return new WaitForSeconds(Random.Range(1, 5));
        StartCoroutine("StartWalking");
    }
}
