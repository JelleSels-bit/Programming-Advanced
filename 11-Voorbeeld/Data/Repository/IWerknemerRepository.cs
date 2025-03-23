﻿using Orders.Models;

namespace Orders.Data.Repository;

public interface IWerknemerRepository
{
    public List<Werknemer> OphalenWerknemers();

    public ICollection<Werknemer> OphalenWerknemersViaFunctie(string functie);

    public IEnumerable<Werknemer> OphalenWerknemersViaAchternaamEnVoornaam(string achternaam, string voornaam);

    public Werknemer OphalenWerknemerViaPK(int werknemerID);
}