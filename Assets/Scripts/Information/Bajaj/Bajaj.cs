using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bajaj :MonoBehaviour, IInformation
{
    public Texture2D[] images;

    public void Initialize()
    {
        images = Resources.LoadAll<Texture2D>("Images/Bajaj");
        System.Array.ForEach(images, x => Debug.LogError(x));
        //images = new Image[];
    }
}
public class informationManager
 {
    public IInformation info;
    public informationManager(IInformation information)
    {
        info = information;
    }
     public void Switch(IInformation information)
    {
        info = information;
    }
    public void InformationInitliaze()
    {
        info.Initialize();
    }
 }
public interface IInformation
{
   public void Initialize();
}