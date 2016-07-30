using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainScreenScript : MonoBehaviour {
    
    public bool LoadingInitiated = false;    

    public void StartGame() {
        if (!LoadingInitiated) {
            Time.timeScale = 1;
            StartCoroutine(PlaySoundAndStart());
            LoadingInitiated = true;                     
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu))                  
            Application.Quit(); 
    }


    IEnumerator PlaySoundAndStart() {
        var audio = GetComponent<AudioSource>();
        audio.volume = 0.165f;
        audio.Play();        
        yield return new WaitForSeconds(audio.clip.length);        
        SceneManager.LoadScene("Game");
    }
}
