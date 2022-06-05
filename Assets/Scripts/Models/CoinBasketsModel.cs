namespace Models
{
    public class CoinBasketsModel
    {
        public float BasketBottomY { get;} 
        public float BasketSpacingY { get;} 
        public int MaxBaskets { get;} 

        public CoinBasketsModel(float basketBottomY, float basketSpacingY, int maxBaskets)
        {
            BasketBottomY = basketBottomY;
            BasketSpacingY = basketSpacingY;
            MaxBaskets = maxBaskets;
        }
    }
}