using MauiApp2.scr.objects;

namespace MauiApp2.services;

public class AdService
{
    public List<Ad> Ads { get; set; }
    
    public AdService()
    {
        Ads = new List<Ad>();
    }
    
    public void AddAd(Ad ad)
    {
        Ads.Add(ad);
    }
    
    public void RemoveAd(Ad ad)
    {
        Ads.Remove(ad);
    }
    
    public List<Ad> GetAds()
    {
        return Ads;
    }
    
    public Ad GetAdById(long id)
    {
        return Ads.FirstOrDefault(a => a.Id == id);
    }

    public Ad UpdateAd(long id, Ad ad)
    {
        Ad existingAd = GetAdById(id);
        if (existingAd != null)
        {
            existingAd.Title = ad.Title;
            existingAd.Description = ad.Description;
            existingAd.StudentId = ad.StudentId;
            existingAd.StudentContact = ad.StudentContact;
        }
        return existingAd;
    }
}

