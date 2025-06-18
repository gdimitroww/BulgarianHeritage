using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BulgarianHeritage.Models;

namespace BulgarianHeritage.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Check if data already exists
            if (context.PointsOfInterest.Any())
            {
                return; // DB has been seeded
            }

            // Seed Points of Interest
            var pointsOfInterest = new[]
            {
                new PointOfInterest
                {
                    Name = "Rila Monastery",
                    NameBulgarian = "Рилски манастир",
                    Description = "The largest and most famous Eastern Orthodox monastery in Bulgaria, founded in the 10th century by St. John of Rila. A UNESCO World Heritage Site known for its stunning architecture and historical significance.",
                    DescriptionBulgarian = "Най-големият и най-известен източноправославен манастир в България, основан през 10-ти век от Свети Йоан Рилски. Обект на световното наследство на ЮНЕСКО, известен със своята зашеметяваща архитектура и историческо значение.",
                    Latitude = 42.1333,
                    Longitude = 23.3400,
                    Category = POICategory.Monastery,
                    MainImageUrl = "/images/rila-monastery.jpg",
                    IsUNESCOSite = true,
                    HasVirtualTour = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Boyana Church",
                    NameBulgarian = "Боянска църква",
                    Description = "A medieval Bulgarian Orthodox church situated in the Boyana quarter of Sofia. Famous for its frescoes from 1259, which are among the most complete and perfectly preserved monuments of East European medieval art.",
                    DescriptionBulgarian = "Средновековна българска православна църква, разположена в квартал Бояна в София. Известна със своите фрески от 1259 г., които са сред най-пълните и отлично запазени паметници на източноевропейското средновековно изкуство.",
                    Latitude = 42.6394,
                    Longitude = 23.2700,
                    Category = POICategory.Church,
                    MainImageUrl = "/images/boyana-church.jpg",
                    IsUNESCOSite = true,
                    HasVirtualTour = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Nessebar Old Town",
                    NameBulgarian = "Стар Несебър",
                    Description = "An ancient city on the Black Sea coast, known for its rich collection of medieval churches and traditional architecture. The old town is situated on a small peninsula and is a UNESCO World Heritage Site.",
                    DescriptionBulgarian = "Древен град на черноморското крайбрежие, известен с богатата си колекция от средновековни църкви и традиционна архитектура. Старият град се намира на малък полуостров и е обект на световното наследство на ЮНЕСКО.",
                    Latitude = 42.6583,
                    Longitude = 27.7356,
                    Category = POICategory.HistoricalTown,
                    MainImageUrl = "/images/nessebar.jpg",
                    IsUNESCOSite = true,
                    HasVirtualTour = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Kazanlak Thracian Tomb",
                    NameBulgarian = "Казанлъшка тракийска гробница",
                    Description = "A vaulted brickwork tomb from the Hellenistic period, dating from the late 4th or early 3rd century BC. Famous for its well-preserved wall paintings depicting Thracian burial rituals.",
                    DescriptionBulgarian = "Сводеста тухлена гробница от елинистическия период, датираща от края на 4-ти или началото на 3-ти век пр.н.е. Известна със своите добре запазени стенописи, изобразяващи тракийски погребални ритуали.",
                    Latitude = 42.6167,
                    Longitude = 25.4000,
                    Category = POICategory.Archaeological,
                    MainImageUrl = "/images/kazanlak-tomb.jpg",
                    IsUNESCOSite = true,
                    HasVirtualTour = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Pirin National Park",
                    NameBulgarian = "Национален парк Пирин",
                    Description = "A national park that encompasses the larger part of the Pirin Mountains in southwest Bulgaria. Known for its diverse ecosystems, glacial lakes, and endemic species.",
                    DescriptionBulgarian = "Национален парк, който обхваща по-голямата част от планината Пирин в югозападна България. Известен със своите разнообразни екосистеми, ледникови езера и ендемични видове.",
                    Latitude = 41.7500,
                    Longitude = 23.4167,
                    Category = POICategory.Nature,
                    MainImageUrl = "/images/pirin-park.jpg",
                    IsUNESCOSite = true,
                    HasVirtualTour = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Tsarevets Fortress",
                    NameBulgarian = "Крепост Царевец",
                    Description = "A medieval stronghold located on a hill with the same name in Veliko Tarnovo. It served as the primary fortress and strongest bulwark of the Second Bulgarian Empire between 1185 and 1393.",
                    DescriptionBulgarian = "Средновековна крепост, разположена на хълм със същото име във Велико Търново. Служила е като основна крепост и най-силна твърдина на Второто българско царство между 1185 и 1393 г.",
                    Latitude = 43.0833,
                    Longitude = 25.6500,
                    Category = POICategory.Fortress,
                    MainImageUrl = "/images/tsarevets.jpg",
                    IsUNESCOSite = false,
                    HasVirtualTour = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Belogradchik Rocks",
                    NameBulgarian = "Белоградчишки скали",
                    Description = "A group of strange shaped sandstone and conglomerate rock formations located near the town of Belogradchik. The rocks vary in color from primarily red to yellow.",
                    DescriptionBulgarian = "Група от странно оформени пясъчникови и конгломератни скални образувания, разположени близо до град Белоградчик. Скалите варират по цвят от предимно червен до жълт.",
                    Latitude = 43.6167,
                    Longitude = 22.6833,
                    Category = POICategory.Nature,
                    MainImageUrl = "/images/belogradchik-rocks.jpg",
                    IsUNESCOSite = false,
                    HasVirtualTour = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PointOfInterest
                {
                    Name = "Bachkovo Monastery",
                    NameBulgarian = "Бачковски манастир",
                    Description = "An important monastery in the Eastern Orthodox world, founded in 1083 by Gregory Pakourianos. It is the second largest monastery in Bulgaria and houses many valuable frescoes and icons.",
                    DescriptionBulgarian = "Важен манастир в източноправославния свят, основан през 1083 г. от Григорий Пакуриан. Това е вторият по големина манастир в България и съхранява много ценни фрески и икони.",
                    Latitude = 41.9333,
                    Longitude = 24.8667,
                    Category = POICategory.Monastery,
                    MainImageUrl = "/images/bachkovo.jpg",
                    IsUNESCOSite = false,
                    HasVirtualTour = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.PointsOfInterest.AddRange(pointsOfInterest);
            await context.SaveChangesAsync();
        }
    }
} 