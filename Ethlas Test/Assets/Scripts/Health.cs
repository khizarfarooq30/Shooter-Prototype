using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviourPunCallbacks
{
    [SerializeField] private Image healthFillImg;
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    [PunRPC]
    public void TakeDamage(int damageAmount)
    {
        if(IsDead()) return;
        
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        healthFillImg.fillAmount = GetHealthAmountNormalized();

        if (IsDead())
        {
            Debug.Log(photonView.Controller.NickName + "  is dead");

            if (photonView.Controller.NickName.Contains("1"))
            {
                ResultManager.Instance.EnableGameOverPanel("Player 2");
            }
            else
            {
                ResultManager.Instance.EnableGameOverPanel("Player 1");
            }
            
            gameObject.SetActive(false);
        }
    }

    private bool IsDead() => currentHealth == 0;

    private float GetHealthAmountNormalized() => (float)currentHealth / maxHealth;

    public bool IsFullHealth() => currentHealth == maxHealth;

}
