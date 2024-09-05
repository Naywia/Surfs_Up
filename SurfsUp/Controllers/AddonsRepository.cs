using SurfsUp.Models;

public static class AddonsRepository
{
    private static List<AddonModel> _addons = new(){
      new AddonModel { Name="Surf Leash – Standard", Type="Standard leash", Description="En robust leash, der findes i længderne 6', 8', og 10'. Designet til at sikre, at dit surfbræt forbliver ved din side under surf sessionen.", ImagePath="/images/addons/leash.png"},
      new AddonModel { Name="Surf Voks – Koldvandsvoks", Type="Voks", Description="Specielt udviklet til at sikre et godt greb på dit surfbræt i lavere vandtemperaturer. Forhindrer, at brættet bliver glat selv i koldt vand.", ImagePath="/images/addons/cold_wax.png"},
      new AddonModel { Name="Rashguard – Langærmet (Mænd)", Type="Rashguard", Description="Tilbyder beskyttelse mod UV-stråler og sand. Ideel til lange surf sessioner og giver ekstra komfort på vandet.", ImagePath="/images/addons/mens_rash_guard.png"},
      new AddonModel { Name="Rashguard – Langærmet (Kvinder)", Type="Rashguard", Description="Tilbyder beskyttelse mod UV-stråler og sand. Ideel til lange surf sessioner og giver ekstra komfort på vandet.", ImagePath="/images/addons/womens_rash_guard.png"},
      new AddonModel { Name="Neopren Handsker – 3mm", Type="Handsker", Description="Designet til at holde dine hænder varme i koldt vand. Fås i forskellige størrelser for at sikre en tætsiddende og komfortabel pasform.", ImagePath="/images/addons/gloves.png"},
      new AddonModel { Name="Surf Voks – Varmvandsvoks", Type="Voks", Description="Tilpasset varmere vandtemperaturer, så du kan få et optimalt greb på dit bræt uden at vokse smelter eller bliver for klæbrigt.", ImagePath="/images/addons/warm_wax.png"},
    };

    public static List<AddonModel> GetAddons() => _addons;
}