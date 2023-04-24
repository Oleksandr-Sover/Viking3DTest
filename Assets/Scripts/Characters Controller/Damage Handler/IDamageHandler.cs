
namespace GameLogic
{
    public interface IDamageHandler
    {
        void SetStartHealth(int health);
        bool DidGetDamage(int currentHealth);
    }
}