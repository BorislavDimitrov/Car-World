namespace CarWorld.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CarWorld.Data.Models;

    public class ModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Models.Any())
            {
                return;
            }

            int audiId = dbContext.Makes.FirstOrDefault(x => x.Name == "Audi").Id;

            await dbContext.Models.AddAsync(new Model { Name = "100", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "200", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "80", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "90", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A1", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A1 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A2", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A3", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A3 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A4", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A4 Allroad", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A4 Avant", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A5", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A5 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A6", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A6 Allroad", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A6 Avant", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A7", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A7 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "A8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q2", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q3", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q3 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q4-Etron", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q5", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q5 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q7", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "Q8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "R8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS3", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS3 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS4", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS5", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS6", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS6 Avant", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS7", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RS7 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "RSQ8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S2", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S3", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S3 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S4", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S5", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S5 Sportback", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S6", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S7", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "S8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "SQ5", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "SQ7", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "SQ8", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "TT", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "TT Roadster", MakeId = audiId });
            await dbContext.Models.AddAsync(new Model { Name = "TTS", MakeId = audiId });

            int bmwId = dbContext.Makes.FirstOrDefault(x => x.Name == "BMW").Id;

            await dbContext.Models.AddAsync(new Model { Name = "116", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "118", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "120", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "123", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "128", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "130", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "130", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "216", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "218", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "220", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "223", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "228", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "230", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "230", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "316", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "318", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "320", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "323", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "328", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "330", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "340", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "416", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "418", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "420", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "423", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "428", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "430", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "440", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "516", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "518", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "520", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "523", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "528", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "530", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "540", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "550", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "630", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "633", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "635", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "640", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "650", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "740", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "735", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "740", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "745", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "750", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "I3", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "I8", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "M3", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "M4", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "M5", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "M6", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "M8", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x2", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x3", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x4", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x5", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x6", MakeId = bmwId });
            await dbContext.Models.AddAsync(new Model { Name = "x7", MakeId = bmwId });

            int vwId = dbContext.Makes.FirstOrDefault(x => x.Name == "VW").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Amarok", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Arteon", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Atlas", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Beetle", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Bora", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Buggy", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Caddy", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Caravelle", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Corrado", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Country", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Crafter", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Eos", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Fox", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Golf", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Jetta", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Lupo", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Beetle", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Passat", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Phaeton", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Polo", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Scirocco", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Sharan", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "T-Cross", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "T-Roc", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Tiguan", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Touran", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Touareg", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Vento", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "up!", MakeId = vwId });
            await dbContext.Models.AddAsync(new Model { Name = "Transporter", MakeId = vwId });

            int mercedesId = dbContext.Makes.FirstOrDefault(m => m.Name == "Mercedes-Benz").Id;

            await dbContext.Models.AddAsync(new Model { Name = "123", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "124", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "126", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "190", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "200", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "208", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "230", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "250", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "260", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "300", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "320", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "420", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "450", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "500", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "560", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 45 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 190", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 200", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 210", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 250", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "A 250 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "B 180", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "B 200", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 180", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 200", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 230", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 240", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 250", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 270", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 280", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 30 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 300", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 32 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 400", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 43 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 55 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "C 63 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "CLC", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "CLK", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 200", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 230", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 240", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 250", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 260", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 280", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 300", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 320", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 400", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 420", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 43 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 430", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 450", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 500", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 53 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 55", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "E 63 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 300", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 320", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 400", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 500", MakeId = mercedesId }); 
            await dbContext.Models.AddAsync(new Model { Name = "C 220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 55 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 550", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "G 63 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "GL 420", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "GL 450", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "GL 500", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "GL 55 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "GL 63 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 320", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 400", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 4220", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 430", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 450", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "ML 500", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 300", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 320", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 350", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 400", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 420", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 450", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 500", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 55", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 550", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 560", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 600", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 63 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 65 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 650", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 30 AMG", MakeId = mercedesId });
            await dbContext.Models.AddAsync(new Model { Name = "S 300", MakeId = mercedesId });

            int opelId = dbContext.Makes.FirstOrDefault(x => x.Name == "Opel").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Adam", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Agila", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Ampera", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Antara", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Arena", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Ascona", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Astra", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Calibra", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Campo", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Combo", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Commodore", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Corsa", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Crassland X", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Frontera", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "GT", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Insignia", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Kadett", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Karl", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Mokka", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Tigra", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Zafira", MakeId = opelId });
            await dbContext.Models.AddAsync(new Model { Name = "Vectra", MakeId = opelId });

            int peugeotId = dbContext.Makes.FirstOrDefault(x => x.Name == "Peugeot").Id;

            await dbContext.Models.AddAsync(new Model { Name = "1007", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "106", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "107", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "108", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "2008", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "205", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "206", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "206 CC", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "207", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "207 CC", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "207 SW", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "208", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "3008", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "301", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "304", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "306", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "307", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "307 CC", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "308 SW", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "308", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "309", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "4007", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "4008", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "404", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "405", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "406", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "407", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "5008", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "504", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "505", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "508", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "604", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Bipper", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Boxer", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Expert", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "IOn", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "J5", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Partner", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Ranch", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "RCZ", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "RIfter", MakeId = peugeotId });
            await dbContext.Models.AddAsync(new Model { Name = "Traveller", MakeId = peugeotId });

            int renaultId = dbContext.Makes.FirstOrDefault(m => m.Name == "Renault").Id;

            await dbContext.Models.AddAsync(new Model { Name = "10", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "11", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "18", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "19", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "21", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "25", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "4", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "5", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "9", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Arkana", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Avantime", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Captur", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Chamade", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Zoe", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Wind", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Vel Satis", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Twizy", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Twingo", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Trafic", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Talisman", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Symbol", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Scenic", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Safrane", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Rapid", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Modus", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Megane", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Master", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Latitude", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Laguna", MakeId = renaultId });
            await dbContext.Models.AddAsync(new Model { Name = "Koleos", MakeId = renaultId });

            int toyotaId = dbContext.Makes.FirstOrDefault(x => x.Name == "Toyota").Id;

            await dbContext.Models.AddAsync(new Model { Name = "4-Runner", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Auris", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Avalon", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Avensis", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Avensis Verso", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Aygo", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "C-HR", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Camry", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Carina", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Celica", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Corolla", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Corolla Verso", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Crown", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "FJ", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "GT86", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Hilux", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "IQ", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Land Cruiser", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Picnic", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Prius", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Proace", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "RAV 4", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Scion", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Sequoia", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Sienna", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Supra", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Tundra", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Tercel", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Tacoma", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Urban Cruiser", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Venza", MakeId = toyotaId });
            await dbContext.Models.AddAsync(new Model { Name = "Yaris", MakeId = toyotaId });
         
            int fordId = dbContext.Makes.FirstOrDefault(m => m.Name == "Ford").Id;

            await dbContext.Models.AddAsync(new Model { Name = "B-Max", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Bronco", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "C-Max", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Connect", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Cougar", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Courier", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "EcoSport", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Edge", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Escape", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Escort", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Expendition", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Explorer", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "F 150", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "F 250", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "F 350", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Fiesta", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Focus", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Focus C-Max", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Fusion", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Galaxy", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Grandana", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Ka", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Kuga", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Taunus", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Taurus", MakeId = fordId });
            await dbContext.Models.AddAsync(new Model { Name = "Transit", MakeId = fordId });

            int cintroenId = dbContext.Makes.SingleOrDefault(m => m.Name == "Citroen").Id;

            await dbContext.Models.AddAsync(new Model { Name = "2 CV", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "AX", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Berlingo", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "BerlingoFT", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "BX", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C-Crosser", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C-Elysee", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C-Zero", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C1", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C15", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C2", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C3", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C3 Aircross", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C3 Picasso", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C4", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C5", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C5 Aircross", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C6", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "C8", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "DS", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "DS3", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "DS4", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "DS5", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Evasion", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Jumper", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Jumpy", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Nemo", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "SAXO", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Visa", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Xantia", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "Xsara", MakeId = cintroenId });
            await dbContext.Models.AddAsync(new Model { Name = "ZX", MakeId = cintroenId });

            int hondaId = dbContext.Makes.FirstOrDefault(x => x.Name == "Honda").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Accord", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Aerodeck", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Civic", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Concerto", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "CR-V", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "CR-Z", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "CRX", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Element", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "FIT", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "FR-V", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "HR-V", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Insight", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Inregra", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Jazz", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "LEgend", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Logo", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Odyssey", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Pilot", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Prelude", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Ridgeline", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "S200", MakeId = hondaId });
            await dbContext.Models.AddAsync(new Model { Name = "Stream", MakeId = hondaId });
        
            int mazdaId = dbContext.Makes.SingleOrDefault(m => m.Name == "Mazda").Id;

            await dbContext.Models.AddAsync(new Model { Name = "121", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "2", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "3", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "323", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "5", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "5 NEW", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "6", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "6 NEW", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "626", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "929", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "BT-50", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "RX-8", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "Premacy", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "CX 3", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "Tribute", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "MX-3", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "MX-5", MakeId = mazdaId });
            await dbContext.Models.AddAsync(new Model { Name = "MX-6", MakeId = mazdaId });

            int nissanId = dbContext.Makes.FirstOrDefault(x => x.Name == "Nissan").Id;

            await dbContext.Models.AddAsync(new Model { Name = "100 NX", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "350 Z", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "370 Z", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Almera", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Almera Tino", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Altima", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Bluebird", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Cherry", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Cube", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Frontier", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "GTR", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Juke", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Leaf", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Maxima", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Micra", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Navara", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Tribute", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Note", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "NP300", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "NV 200", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Patrol", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Pixo", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Primera", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "Skyline", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "X-Terra", MakeId = nissanId });
            await dbContext.Models.AddAsync(new Model { Name = "X-Trail", MakeId = nissanId });

            int fiatId = dbContext.Makes.FirstOrDefault(m => m.Name == "Fiat").Id;

            await dbContext.Models.AddAsync(new Model { Name = "125", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "126", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "127", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "131", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "500", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "500L", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "500X", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "595C", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "600", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Albea", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Brava", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Bravo", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Coupe", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Dino", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Doblo", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Ducato", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Fiorino", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Freemont", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Fullback", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Grande Punto", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Tipo", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Stilo", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Multima", MakeId = fiatId });
            await dbContext.Models.AddAsync(new Model { Name = "Tempra", MakeId = fiatId });

            int seatId = dbContext.Makes.FirstOrDefault(x => x.Name == "Seat").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Alhambra", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Altea", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Arona", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Arosa", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Ateca", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Cordoba", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Exeo", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Ibiza", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Inca", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Leon", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Leon ST", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Mii", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Tarraco", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Terra", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Toledo", MakeId = seatId });
            await dbContext.Models.AddAsync(new Model { Name = "Vario", MakeId = seatId });

            int skodaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Skoda").Id;

            await dbContext.Models.AddAsync(new Model { Name = "105", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "120", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "130", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Citigo", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Fabia", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Favorit", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Felicia", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Forman", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Yeti", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Karoq", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Kodiaq", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Octavia", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Rapid", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Roomster", MakeId = skodaId });
            await dbContext.Models.AddAsync(new Model { Name = "Superb", MakeId = skodaId });

            int mitsubishiId = dbContext.Makes.FirstOrDefault(m => m.Name == "Mitsubishi").Id;

            await dbContext.Models.AddAsync(new Model { Name = "3000 GT", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "ASX", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Carisma", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Colt", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Eclipse", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Galant", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Grandis", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "L200", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "L300", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "L400", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Lancer", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Outlander", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Pajero", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Sigma", MakeId = mitsubishiId });
            await dbContext.Models.AddAsync(new Model { Name = "Space Wagon", MakeId = mitsubishiId });

            int hyundaiId = dbContext.Makes.FirstOrDefault(m => m.Name == "Hyundai").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Accent", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Atos", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Bayon", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Coupe", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Elantra", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Galloper", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Genesis", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Getz", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "i10", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "i20", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "i30", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "i30CW", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "i40", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "ix20", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "ix35", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "ix55", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Kona", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Sontana", MakeId = hyundaiId });
            await dbContext.Models.AddAsync(new Model { Name = "Tucson", MakeId = hyundaiId });

            int kiaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Kia").Id;

            await dbContext.Models.AddAsync(new Model { Name = "K 5", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Candenza", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Carens", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Carnival", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Ceed", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Clarus", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Elan", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Joice", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "K2700", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Magentis", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Nicro", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Opirus", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Optima", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Pride", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Rio", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Sephia", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Stringer", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Venga", MakeId = kiaId });
            await dbContext.Models.AddAsync(new Model { Name = "Sportage", MakeId = kiaId });

            int suzukiId = dbContext.Makes.FirstOrDefault(m => m.Name == "Suzuki").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Alto", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Baleno", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Cappuccino", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Celerio", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Grand Vitara", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Ignis", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Jimny", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Kizashi", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Liana", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Maruti", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "SJ Samurai", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Splash", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Swift", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "SX4", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "SX4 S-Cross", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Vitara", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "X-90", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "Wagon R+", MakeId = suzukiId });
            await dbContext.Models.AddAsync(new Model { Name = "XL7", MakeId = suzukiId });

            int volvoId = dbContext.Makes.FirstOrDefault(m => m.Name == "Volvo").Id;

            await dbContext.Models.AddAsync(new Model { Name = "XC 60", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "XC 70", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "XC 90", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "XC 40", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "V40", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "V50", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "V60", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "V70", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "V90", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "Amazon", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "C30", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "C70", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "S40", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "S60", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "S70", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "S80", MakeId = volvoId });
            await dbContext.Models.AddAsync(new Model { Name = "S90", MakeId = volvoId });

            int subaruId = dbContext.Makes.FirstOrDefault(m => m.Name == "Subaru").Id;

            await dbContext.Models.AddAsync(new Model { Name = "B9 Tribeca", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Baja", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "BRZ", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Forest", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Impreza", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Justy", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Legacy", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Levorg", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Libero", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "OUTBACK", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "SVX", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Trezia", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "Vivio", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "WRX", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "XT", MakeId = subaruId });
            await dbContext.Models.AddAsync(new Model { Name = "XV", MakeId = subaruId });

            int alfaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Alfa Romeo").Id;

            await dbContext.Models.AddAsync(new Model { Name = "145", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "146", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "147", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "155", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "156", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "159", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "164", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "166", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "33", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "Arna", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "Brera", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "Crosswagon", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "Giulia", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "Giulietta", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "GT", MakeId = alfaId });
            await dbContext.Models.AddAsync(new Model { Name = "MiTo", MakeId = alfaId });

            int chevroletId = dbContext.Makes.FirstOrDefault(m => m.Name == "Chevrolet").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Avalanche", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Aveo", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Beretta", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Blazer", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "C155", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Camaro", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Captiva", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Cobalt", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Corvette", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Curtez", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Epica", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Impala", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Epica", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Trax", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Volt", MakeId = chevroletId });
            await dbContext.Models.AddAsync(new Model { Name = "Malibu", MakeId = chevroletId });

            int daciaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Dacia").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Dokker", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Duster", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Lodgy", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Logan", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Pick up", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Sandero", MakeId = daciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Solenza", MakeId = daciaId });

            int landRoverId = dbContext.Makes.FirstOrDefault(m => m.Name == "Land Rover").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Defender", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Discovery", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Discovery 3", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Discovery Sport", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Freelander", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Land Rover I", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Land Rover II", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Range Rover", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Range Rover Evoque", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Range Rover Sport", MakeId = landRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Range Rover Vogue", MakeId = landRoverId });

            int jeepId = dbContext.Makes.FirstOrDefault(m => m.Name == "Jeep").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Cheeroke", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Commander", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Compass", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Grand Cherokee", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Liberty", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Patriot", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Renegade", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Wagoneer", MakeId = jeepId });
            await dbContext.Models.AddAsync(new Model { Name = "Wrangler", MakeId = jeepId });

            int miniId = dbContext.Makes.FirstOrDefault(m => m.Name == "Mini").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Clubman", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "Cooper", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "Cooper S", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "Countryman", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "John Cooper Works", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "ONE", MakeId = miniId });
            await dbContext.Models.AddAsync(new Model { Name = "Paceman", MakeId = miniId });

            int lanciaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Lancia").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Dedra", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Delta", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Flavia", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Kappa", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Lybra", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "MUSA", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Phedra", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Thema", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Thesis", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Y", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Ypsilon", MakeId = lanciaId });
            await dbContext.Models.AddAsync(new Model { Name = "Zeta", MakeId = lanciaId });

            int chryslerId = dbContext.Makes.FirstOrDefault(m => m.Name == "Chrysler").Id;

            await dbContext.Models.AddAsync(new Model { Name = "300 M", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "300C", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Crossfire", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Grand Voyager", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Le Baron", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Neon", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "New Yorker", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Pacifica", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "PT Cruiser", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Sebring", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Stratus", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Vision", MakeId = chryslerId });
            await dbContext.Models.AddAsync(new Model { Name = "Voyager", MakeId = chryslerId });

            int jaguarId = dbContext.Makes.FirstOrDefault(m => m.Name == "Jaguar").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Daimler", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "E Type", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "E-Pace", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "F Type", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "F-Pace", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "I-Pace", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "S Type", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "X Type", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XE", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XF", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJ", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJ12", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJ40", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJ6", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJ8", MakeId = jaguarId });
            await dbContext.Models.AddAsync(new Model { Name = "XJR", MakeId = jaguarId });

            int smartId = dbContext.Makes.FirstOrDefault(m => m.Name == "Smart").Id;

            await dbContext.Models.AddAsync(new Model { Name = "ForFour", MakeId = smartId });
            await dbContext.Models.AddAsync(new Model { Name = "ForTwo", MakeId = smartId });
            await dbContext.Models.AddAsync(new Model { Name = "Mc", MakeId = smartId });
            await dbContext.Models.AddAsync(new Model { Name = "Micro", MakeId = smartId });
            await dbContext.Models.AddAsync(new Model { Name = "Roadster", MakeId = smartId });

            int porscheId = dbContext.Makes.FirstOrDefault(m => m.Name == "Porsche").Id;

            await dbContext.Models.AddAsync(new Model { Name = "911", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "911 Turbo Cabrio", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "912", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "924", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Boxer", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Boxer S", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Carrera", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Cayenne", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Cayman", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Macan", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Panamera", MakeId = porscheId });
            await dbContext.Models.AddAsync(new Model { Name = "Taycan", MakeId = porscheId });

            int roverId = dbContext.Makes.FirstOrDefault(m => m.Name == "Rover").Id;

            await dbContext.Models.AddAsync(new Model { Name = "200", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "214", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "216", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "25", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "400", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "414", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "416", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "420", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "45", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "600", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "618", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "620", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "75", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "820", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "ZT", MakeId = roverId });
            await dbContext.Models.AddAsync(new Model { Name = "City Rover", MakeId = roverId });

            int saabId = dbContext.Makes.FirstOrDefault(m => m.Name == "Saab").Id;

            await dbContext.Models.AddAsync(new Model { Name = "9-3", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "9-3x", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "9-5", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "9-7X", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "900", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "9000", MakeId = saabId });
            await dbContext.Models.AddAsync(new Model { Name = "99", MakeId = saabId });

            int lexusId = dbContext.Makes.FirstOrDefault(m => m.Name == "Lexus").Id;

            await dbContext.Models.AddAsync(new Model { Name = "CT 200h", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "ES350", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "GS", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "GS300", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "GS430", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "GS450", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "IS200", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "IS220", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "IS250", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "IS300", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "RX400", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "RX400h", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "RX450", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "SC400", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "SC430", MakeId = lexusId });
            await dbContext.Models.AddAsync(new Model { Name = "UX", MakeId = lexusId });

            int ladaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Lada").Id;

            await dbContext.Models.AddAsync(new Model { Name = "1200", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "1300", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "1500", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "1600", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2101", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "21011", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "21013", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2102", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2103", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2104", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2105", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "21051", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2106", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "21061", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "2107", MakeId = ladaId });
            await dbContext.Models.AddAsync(new Model { Name = "Niva", MakeId = ladaId });

            int infinityId = dbContext.Makes.FirstOrDefault(m => m.Name == "Infinity").Id;

            await dbContext.Models.AddAsync(new Model { Name = "EX", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "FX", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "G35", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "G37", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "M", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "Q45", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "Q30", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "Q50", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "Q60", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "Q70", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX30", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX50", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX56", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX60", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX70", MakeId = infinityId });
            await dbContext.Models.AddAsync(new Model { Name = "QX80", MakeId = infinityId });

            int dodgeId = dbContext.Makes.FirstOrDefault(m => m.Name == "Dodge").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Avenger", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Caliber", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Challenger", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Charger", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Dakota", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Durango", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Ggrand Caravan", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Journey", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Magnum", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Nitro", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Ram", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Shadow", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Stealth", MakeId = dodgeId });
            await dbContext.Models.AddAsync(new Model { Name = "Stratus", MakeId = dodgeId });

            int isuzuId = dbContext.Makes.FirstOrDefault(m => m.Name == "Isuzu").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Campo", MakeId = isuzuId });
            await dbContext.Models.AddAsync(new Model { Name = "D-Max", MakeId = isuzuId });
            await dbContext.Models.AddAsync(new Model { Name = "PICK UP", MakeId = isuzuId });
            await dbContext.Models.AddAsync(new Model { Name = "Rodeo", MakeId = isuzuId });
            await dbContext.Models.AddAsync(new Model { Name = "Trooper", MakeId = isuzuId });

            int teslaId = dbContext.Makes.FirstOrDefault(m => m.Name == "Tesla").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Model 3", MakeId = teslaId });
            await dbContext.Models.AddAsync(new Model { Name = "Model S", MakeId = teslaId });
            await dbContext.Models.AddAsync(new Model { Name = "Model X", MakeId = teslaId });
            await dbContext.Models.AddAsync(new Model { Name = "Model Y", MakeId = teslaId });

            int rangeRoverId = dbContext.Makes.FirstOrDefault(m => m.Name == "Range Rover").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Defender", MakeId = rangeRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Discovery 4", MakeId = rangeRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Evoque", MakeId = rangeRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Freelander 2", MakeId = rangeRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Range Rover", MakeId = rangeRoverId });
            await dbContext.Models.AddAsync(new Model { Name = "Sport", MakeId = rangeRoverId });

            int moskvichId = dbContext.Makes.FirstOrDefault(m => m.Name == "Moskvich").Id;

            await dbContext.Models.AddAsync(new Model { Name = "1500", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "2140", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "2141", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "21412", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "403", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "47", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "408", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "412", MakeId = moskvichId });
            await dbContext.Models.AddAsync(new Model { Name = "Aleko", MakeId = moskvichId });

            int cadilacId = dbContext.Makes.FirstOrDefault(m => m.Name == "Cadillac").Id;

            await dbContext.Models.AddAsync(new Model { Name = "BLC", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "BLS", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "CTS", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "Deville", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "Eldorado", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "Escalade", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "Fleetwood", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "Seville", MakeId = cadilacId });
            await dbContext.Models.AddAsync(new Model { Name = "SRX", MakeId = cadilacId });

            int trabantId = dbContext.Makes.FirstOrDefault(m => m.Name == "Trabant").Id;

            await dbContext.Models.AddAsync(new Model { Name = "600", MakeId = trabantId });
            await dbContext.Models.AddAsync(new Model { Name = "601", MakeId = trabantId });
            await dbContext.Models.AddAsync(new Model { Name = "Combi", MakeId = trabantId });

            int hummerId = dbContext.Makes.FirstOrDefault(m => m.Name == "Hummer").Id;

            await dbContext.Models.AddAsync(new Model { Name = "H2", MakeId = hummerId });
            await dbContext.Models.AddAsync(new Model { Name = "H3", MakeId = hummerId });

            int maseratiId = dbContext.Makes.FirstOrDefault(m => m.Name == "Maserati").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Ghibli", MakeId = maseratiId });
            await dbContext.Models.AddAsync(new Model { Name = "Granturismo", MakeId = maseratiId });
            await dbContext.Models.AddAsync(new Model { Name = "Levante", MakeId = maseratiId });
            await dbContext.Models.AddAsync(new Model { Name = "Quattroporte", MakeId = maseratiId });
            await dbContext.Models.AddAsync(new Model { Name = "Quattroporte S", MakeId = maseratiId });
            await dbContext.Models.AddAsync(new Model { Name = "Quattroporte Sport GT S", MakeId = maseratiId });

            int bentleyId = dbContext.Makes.FirstOrDefault(m => m.Name == "Bentley").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Bentayga", MakeId = bentleyId });
            await dbContext.Models.AddAsync(new Model { Name = "Continental", MakeId = bentleyId });
            await dbContext.Models.AddAsync(new Model { Name = "Flying Spur", MakeId = bentleyId });
            await dbContext.Models.AddAsync(new Model { Name = "Mulsane", MakeId = bentleyId });

            int ivecoId = dbContext.Makes.FirstOrDefault(m => m.Name == "Iveco").Id;

            await dbContext.Models.AddAsync(new Model { Name = "2.8", MakeId = ivecoId });
            await dbContext.Models.AddAsync(new Model { Name = "35", MakeId = ivecoId });
            await dbContext.Models.AddAsync(new Model { Name = "3510", MakeId = ivecoId });
            await dbContext.Models.AddAsync(new Model { Name = "35c13", MakeId = ivecoId });
            await dbContext.Models.AddAsync(new Model { Name = "35s13", MakeId = ivecoId });
            await dbContext.Models.AddAsync(new Model { Name = "Daily", MakeId = ivecoId });

            int rollsRoyceId = dbContext.Makes.FirstOrDefault(m => m.Name == "Rolls Royce").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Corniche", MakeId = rollsRoyceId });
            await dbContext.Models.AddAsync(new Model { Name = "Pantom", MakeId = rollsRoyceId });
            await dbContext.Models.AddAsync(new Model { Name = "Silver Spur", MakeId = rollsRoyceId });
            await dbContext.Models.AddAsync(new Model { Name = "Silver Wraith", MakeId = rollsRoyceId });

            int ferrariId = dbContext.Makes.FirstOrDefault(m => m.Name == "Ferrari").Id;

            await dbContext.Models.AddAsync(new Model { Name = "458", MakeId = ferrariId });
            await dbContext.Models.AddAsync(new Model { Name = "599 GTB", MakeId = ferrariId });
            await dbContext.Models.AddAsync(new Model { Name = "812", MakeId = ferrariId });
            await dbContext.Models.AddAsync(new Model { Name = "Portfino", MakeId = ferrariId });           

            int buickId = dbContext.Makes.FirstOrDefault(m => m.Name == "Buick").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Century", MakeId = buickId });
            await dbContext.Models.AddAsync(new Model { Name = "Regal", MakeId = buickId });
            await dbContext.Models.AddAsync(new Model { Name = "Randezvous", MakeId = buickId });

            int lamborghiniId = dbContext.Makes.FirstOrDefault(m => m.Name == "Lamborghini").Id;

            await dbContext.Models.AddAsync(new Model { Name = "Usur", MakeId = lamborghiniId });
            await dbContext.Models.AddAsync(new Model { Name = "Huracan", MakeId = lamborghiniId });

            int maychachId = dbContext.Makes.FirstOrDefault(m => m.Name == "Maybach").Id;

            await dbContext.Models.AddAsync(new Model { Name = "57", MakeId = maychachId });
            await dbContext.Models.AddAsync(new Model { Name = "62", MakeId = maychachId });

            int astonMartinId = dbContext.Makes.FirstOrDefault(m => m.Name == "Aston Martin").Id;

            await dbContext.Models.AddAsync(new Model { Name = "V8 Vintage", MakeId = astonMartinId });
  
            await dbContext.SaveChangesAsync();
        }
    }
}
