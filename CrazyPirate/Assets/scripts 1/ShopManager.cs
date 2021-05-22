using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField]  private int indexNow;
    public int number;
    [SerializeField] private SetSkins setSkins;
    [SerializeField] private Text GoldText;
    [SerializeField] private Text priceText;
    [SerializeField] private int[] price;
    private void Start()
    {
        
        number = 0;
        index = setSkins.index;
        indexNow = index;
        Main.Gold = PlayerPrefs.GetInt("Gold");
        GoldText.text = Main.Gold.ToString();
        Skin();
        
    }
    public void SkinMinus()
    {
        if (index > 0)
            index--;
        else
            index = 4;
        Skin();
    }
    public void SkinPlus()
    {
        if (index < 4)
            index++;
        else
            index = 0;
        Skin();
    }
    
    private void Skin()
    {
        
        setSkins.UpdateSkin(index);
        number = 5;
        GoldText.text = Main.Gold.ToString();
        priceText.text = price[index].ToString();
        if (Main.Gold >= price[index])
            priceText.color = new Color(0.3087125f, 0.6132076f, 0.1995817f);
        else if (Main.Gold < price[index])
            priceText.color = new Color(0.7169812f, 0.2130652f, 0.2130652f);

        if (indexNow == index)
        {
            priceText.color = new Color(0.01286045f, 0.1474108f, 0.1603774f);
            priceText.text = "Выбрано";
           
        }
        else if (PlayerPrefs.GetInt("Skin" + index.ToString()) == 1 || index == 0)
        {
            priceText.color = new Color(0.01286045f, 0.1474108f, 0.1603774f);
            priceText.text = "Выбрать";
        }
    }
    public void BuySkin()
    {
        Skin();
        if (PlayerPrefs.GetInt("Skin" + index.ToString()) == 1 || index == 0)
        {
            PlayerPrefs.SetInt("index", index);
            priceText.color = new Color(0.01286045f, 0.1474108f, 0.1603774f);
            priceText.text = "Выбрано";
            indexNow = index;
        }
        else if (PlayerPrefs.GetInt("Skin" + index.ToString()) == 0)
        {
            if (Main.Gold >= price[index])
            {
                Main.Gold -= price[index];
                priceText.text = price[index].ToString();
                PlayerPrefs.SetInt("Gold", Main.Gold);
                PlayerPrefs.SetInt("Skin" + index.ToString(), 1);
            }
            Skin();
        }
    }
}