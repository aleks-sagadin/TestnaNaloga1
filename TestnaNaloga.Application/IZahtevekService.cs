using TestnaNaloga.Domain;

namespace TestnaNaloga.Application
{

    // this is use case
    public interface IZahtevekService
    {

        List<Zahtevek> GetAllZahtevek();
        Zahtevek? GetZahtevek(int id);
        Zahtevek CreateZahtevek(Zahtevek zahtevek);
        Zahtevek? UpdateZahtevek(int id, Zahtevek zahtevek);
        Zahtevek? DeleteZahtevek(int id);


    }
}
