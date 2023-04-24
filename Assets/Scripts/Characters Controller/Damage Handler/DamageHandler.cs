
namespace GameLogic
{
    public class DamageHandler : IDamageHandler
    {
        int lastHealth;

        public void SetStartHealth(int health) => lastHealth = health;
         
        public bool DidGetDamage(int currentHealth)
        {
            if (lastHealth != currentHealth)
            {
                lastHealth = currentHealth;
                return true;
            }
            else
                return false;
        }
    }
}