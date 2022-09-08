using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    public TextMeshProUGUI Score;
    public float time = 10f;
    public int mainmenu;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && time > 0f)
        {
            //print(score);
            time = time + 8;
            score = score + 1;
            Animal animal = other.GetComponent<Animal>();
            animal.go();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = time - 1f * Time.deltaTime;
        TimeSpan timenice = TimeSpan.FromSeconds(time);
        if (time > 0f && score < 7)
        {
            TextMesh.text = timenice.ToString(@"ss\:ff");
            Score.text = score.ToString();
        }
        else if (score == 7)
        {
            TextMesh.text = "WELL DONE!";
            StartCoroutine(Loss());
        }
        else
        {
            TextMesh.text = "TIME IS UP!";
            StartCoroutine(Loss());
        }

    }




    public IEnumerator Loss()
    {
        yield return new WaitForSeconds(1.5f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(mainmenu);
    }
}
