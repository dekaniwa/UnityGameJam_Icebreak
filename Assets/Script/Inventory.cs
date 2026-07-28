using UnityEngine;

public class Inventory : MonoBehaviour
{
 
        public static Inventory Instance;

        public int apple;
        public int lemon;
        public int banana;
    public int carrot;
    public int orange;

        void Awake()
        {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        }
    public int GetItemCount()
    {
        return apple + lemon + carrot + banana + orange;
    }

    public void AddApple()
        {
        apple++;
        }
    public void AddLemon()
    {
       
        lemon++;
    }
    public void AddBanana()
    {
        banana++;
    }
    public void AddCarrot()
    {
        carrot++;
    }
    public void AddOrange()
    {
        orange++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
