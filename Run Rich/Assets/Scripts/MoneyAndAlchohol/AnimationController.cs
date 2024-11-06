using UnityEngine;

public class AnimationController : MonoBehaviour
{
     Animator characterAnimator;
    PlayerMovement playerMovement;
    [SerializeField] GameObject[] Customs;
    int CustomCount;
    private void Start()
    {
        if (Customs == null) gameObject.SetActive(false);
        characterAnimator = GetComponent<Animator>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        UpdateCustomCharacter();
    }
   void UpdateCustomCharacter()
    {
        if(CustomCount != 0)
        {
            Customs[0].SetActive(false);
            Customs[CustomCount].SetActive(true);
        }
       
    }
    public void PlayAnimation(string triggerName)
    {
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger(triggerName);
        }
    }

    public void StartMethodInAnimation()
    {
        playerMovement.enabled = false;
    }
    public void PlayerCustomCount(int customCount)
    {
        CustomCount = customCount;
    }

    public void EndMethodInAnimation()
    {
        playerMovement.enabled = true;
        Customs[CustomCount - 1].SetActive(false);
        Customs[CustomCount].SetActive(true);
        characterAnimator.SetTrigger("Exit");
    }

}