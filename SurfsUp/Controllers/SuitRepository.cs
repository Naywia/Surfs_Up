using SurfsUp.Models;

public static class SuitRepository
{
    private static List<SuitModel> _suits = new(){
      new SuitModel { Name="O'Neill Epic 4/3mm Full Wetsuit", Sizes="S, M, L, XL", Type="Fuld våddragt", Description="Perfekt til koldere vandforhold, denne dragt giver fremragende varmeisolering og fleksibilitet med sin 4/3mm tykkelse."},
      new SuitModel { Name="Rip Curl Dawn Patrol 3/2mm Steamer", Sizes="XS, S, M, L, XL", Type="Fuld våddragt", Description="En alsidig dragt, der kombinerer komfort og holdbarhed. Ideel til forår og efterår, hvor vandtemperaturen er moderat."},
      new SuitModel { Name="Billabong Absolute 2mm Shorty Wetsuit", Sizes="S, M, L, XL", Type="Kort våddragt (Shorty)", Description="Denne kortærmede dragt er perfekt til sommermånederne og tilbyder god bevægelsesfrihed i varmere vand."},
      new SuitModel { Name="Quiksilver Syncro 5/4/3mm Hooded Wetsuit", Sizes="M, L, XL, XXL", Type="Fuld våddragt med hætte", Description="Designet til de koldeste forhold. Med en hætte og ekstra tykkelse giver denne dragt maksimal beskyttelse mod kulden."},
      new SuitModel { Name="Xcel Comp 3/2mm Full Wetsuit", Sizes="S, M, L, XL", Type="Fuld våddragt", Description="Kendt for sin fleksibilitet og komfort, denne dragt er ideel til dem, der ønsker en letvægtsløsning til mellemtempereret vand."},
      new SuitModel { Name="Patagonia R2 Yulex 3.5/3mm Front-Zip Wetsuit", Sizes="XS, S, M, L", Type="Fuld våddragt", Description="Lavet af miljøvenligt Yulex-materiale, denne dragt giver fremragende varmeisolering og holdbarhed med ekstra fleksibilitet."},
      new SuitModel { Name="Vissla 7 Seas 2/2mm Long Sleeve Spring Suit", Sizes="S, M, L", Type="Langærmet Spring Suit", Description="Denne dragt er perfekt til de varme forårsdage, hvor du stadig har brug for lidt beskyttelse, men ikke ønsker fuld dækning."},
    };

    public static List<SuitModel> GetSuits() => _suits;
}