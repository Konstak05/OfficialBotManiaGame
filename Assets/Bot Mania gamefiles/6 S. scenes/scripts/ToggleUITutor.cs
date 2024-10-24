using UnityEngine;
using UnityEngine.UI;

public class ToggleUITutor : MonoBehaviour
{
    public AudioClip mySoundClip;
    public WeaponScript WeaponScript;
    public AudioSource Sound;
    public float volume;
    public GameObject uiPanel;
    public float Soundreset = 1f;
    public WeaponScript IsHealing;
    public GameObject Player;
    public int PauseMenuTutor;

    void Start()
    {
            uiPanel.SetActive(false);
            PauseMenuTutor = 0;
            Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Player.GetComponent<KeyboardControlMk2>().HP > 0 && IsHealing.IsHealingPlayer == 0 && PlayerPrefs.GetInt("MenuUnlocked") == 0)
        {
            if(Soundreset >= 1f){
            float audioVolume = PlayerPrefs.GetFloat("AudioVolume");
            float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            Sound.volume = audioVolume * masterVolume * 0.5f;
            Sound.PlayOneShot(mySoundClip);
            Soundreset = 0f;
            uiPanel.SetActive(!uiPanel.activeSelf);
            }

        if (!uiPanel.activeSelf)
        {
          PauseMenuTutor = 0;
        }
        else{
          PauseMenuTutor = 1;
        }
        }

     if(Player.GetComponent<KeyboardControlMk2>().HP <= 0){
        uiPanel.SetActive(false);
        PauseMenuTutor = 0;
     }

      if(Soundreset < 1f && Player.GetComponent<KeyboardControlMk2>().HP > 0){
         Soundreset += 0.1f;
      }
  }
}