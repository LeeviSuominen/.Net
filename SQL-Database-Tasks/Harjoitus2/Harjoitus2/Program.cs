using Harjoitus2;

// Console.WriteLine($"Yhteyden tarjoaa {ProjectConstants.DatabaseProvider}.");

// Metodi kutsut
//QueringLogins();
//QueringLoginsByName("mrbigman");
AddLogins("1234", "Spede");

static void QueringLogins()
{
    using (Pelitietokanta pelitietokanta = new())
    {
        Console.WriteLine("Kirjautuneet käyttäjät:");
        
        // Kysely hakee kaikki Logins taulun tietueet
        IQueryable<Login>? logins = pelitietokanta.Logins;

        // Tarkistaa onko rekisteröityneitä pelaajia
        if(logins is null)
        {
            Console.WriteLine("Yhtään pelaajaa ei ole rekisteröitynyt");
            return;
        }

        // Käy tietueet läpi ja tulostaa ne näytölle    

        foreach (Login login in logins)
        {
            // Tulosta
            Console.WriteLine(login.Nickname);
        }
    }
}

static void QueringLoginsByName(string name)
{
    using (Pelitietokanta pelitietokanta = new())
    {
        // Haetaan tiedot muistiin
        IQueryable<Login>? logins = pelitietokanta.Logins?.Where(login => login.Nickname == name);

        if(logins is null)
        {
            Console.WriteLine("Pelaajaa ei löydy!");
            return;
        }

        // Käydään tietoja läpi ja tulostetaan ne
        foreach (Login login in logins)
        {
            Console.WriteLine($"{name} salasana on {login.Pincode}");
        }
    }
}

static bool AddLogins(string _pincode, string _nickname)
{
    using (Pelitietokanta pelitietokanta = new())
    {
        Login login = new();
        {
            login.Pincode = _pincode;
            login.Nickname = _nickname;
        }

        // Pelaajaa ollaan tallentamassa
        pelitietokanta.Logins?.Add(login);

        // Pelaaja tallennetaan tietokantaan
        int affected = pelitietokanta.SaveChanges();
        return(affected == 1);
    }
}