using Microsoft.Extensions.Logging;
using TestnaNaloga.Domain;

namespace TestnaNaloga.Application
{
    public class ZahtevekService : IZahtevekService
    {
        private readonly IZahtevekRepository _zahtevekRepository;

        private readonly ILogger<ZahtevekService> logger;

        public ZahtevekService(IZahtevekRepository zahtevekRepository, ILogger<ZahtevekService> logger)
        {
            _zahtevekRepository = zahtevekRepository;
            this.logger = logger;
        }

        public List<Zahtevek> GetAllZahtevek()
        {
            logger.LogInformation("[GetAllZahtevek] Start of method");
            return _zahtevekRepository.GetAll();
        }

        public Zahtevek? GetZahtevek(int id)
        {
            logger.LogInformation("[GetZahtevek] Start of method");
            var zahtevek = _zahtevekRepository.GetOneZahtevek(id);
            CheckIfIsNull(id, zahtevek);

            return zahtevek;
        }

        public Zahtevek CreateZahtevek(Zahtevek zahtevek)
        {
            logger.LogInformation("[CreateZahtevek] Start of method");
            //  overwrite passed dates, add now 
            zahtevek.CretedDate = DateTime.Now;
            zahtevek.UpdatedDate = DateTime.Now;

            _zahtevekRepository.AddZahtevek(zahtevek);
            logger.LogInformation("[CreateZahtevek] Zahtevek removed");
            return zahtevek;
        }

        public Zahtevek? UpdateZahtevek(int id, Zahtevek zahtevek)
        {
            logger.LogInformation("[UpdateZahtevek] Start of method");
            // use already definded method for searching by id
            var zahtevekOld = _zahtevekRepository.GetOneZahtevek(id);
            CheckIfIsNull(id, zahtevekOld);

            // update entire
            UpdateObject(zahtevekOld!, zahtevek);

            _zahtevekRepository.ModifyZahtevek(id, zahtevek);
            logger.LogInformation("[UpdateZahtevek] Zahtevek updated");
            return zahtevek;

        }

        public Zahtevek? DeleteZahtevek(int id)
        {
            logger.LogInformation("[DeleteZahtevek] Start of method");
            var zahtevek = _zahtevekRepository.GetOneZahtevek(id);
            // delete zahtevek
            zahtevek = _zahtevekRepository.DeleteZahtevek(zahtevek!);
            logger.LogInformation("[UpdateZahtevek] Zahtevek removed");
            return zahtevek;
        }

        /**
         * Set objecg with new values
         */
        public Zahtevek? UpdateObject(Zahtevek zahtevekOld, Zahtevek zahtevek)
        {

            zahtevekOld.Title = zahtevek.Title;
            zahtevekOld.Description = zahtevek.Description;
            zahtevekOld.IsCompleted = zahtevek.IsCompleted;
            zahtevekOld.DueDate = zahtevek.DueDate;
            zahtevekOld.Priority = zahtevek.Priority;
            zahtevekOld.CretedDate = zahtevek.CretedDate;
            // new time 
            zahtevek.UpdatedDate = DateTime.Now;

            return zahtevek;
        }

        /**
         * Method check if is null
         */
        public void CheckIfIsNull(int id, Zahtevek? zahtevek)
        {
            if (zahtevek == null)
            {
                // Add LOGS
                logger.LogError("[GetZahtevek] Zahtevek with ID {} was not found.", id);
                throw new KeyNotFoundException($"Zahtevek with ID {id} was not found.");
            }

        }
    }
}

