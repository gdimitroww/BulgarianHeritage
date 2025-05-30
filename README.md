# 🇧🇬 Bulgarian Heritage - Discover Bulgaria's Cultural Treasures

Hey there! Welcome to my Bulgarian Heritage project - a web app I built to showcase the amazing cultural heritage sites across Bulgaria. Having grown up fascinated by Bulgaria's rich history, I wanted to create something that makes exploring these incredible places more accessible and engaging for everyone.

## What's This All About? 🤔

This project started as my way of combining my love for Bulgarian culture with web development. The app helps people discover and explore heritage sites throughout Bulgaria - from ancient Thracian tombs to medieval monasteries and everything in between.

## Cool Features I've Built 🚀

- 🗺️ **Interactive Map** - Click around and find heritage sites near you
- 🏛️ **Heritage Site Database** - Detailed info about each location with photos and descriptions  
- 🔍 **Smart Search** - Find sites by name, category, or even UNESCO status
- 👤 **User Accounts** - Sign up to save your favorite spots and plan visits
- 📝 **Reviews & Photos** - Share your experiences and help other travelers
- 📱 **Mobile Friendly** - Works great on your phone for when you're actually visiting sites
- 🎨 **Ethereal Design** - I spent way too much time making this look mystical and cool

## Tech Stack (For the Nerds) 💻

I built this using:
- **ASP.NET Core 9.0** - Because C# is awesome
- **SQL Server 2022** - For all the data storage
- **Bootstrap 5 + Custom CSS** - Making it look pretty
- **Entity Framework** - Database magic
- **Docker** - So you can run it anywhere without the "works on my machine" problem

## Getting Started 🎯

Want to try it out? Here's how:

### The Easy Way (Docker)
```bash
# Grab the code
git clone https://github.com/gdimitroww/BulgarianHeritage.git
cd BulgarianHeritage

# Set up the database (first time only)
docker-compose --profile setup up migration

# Fire it up!
docker-compose up -d
```

Then just open http://localhost:5001 in your browser and you're good to go!

### Running It Locally
If you're a developer and want to mess around with the code:

1. Install .NET 9 SDK
2. Install SQL Server (or keep using Docker for just the database)
3. Update the connection string in `appsettings.json`
4. Run the migrations: `dotnet ef database update`
5. Start it up: `dotnet run`

## Project Structure 📁

```
BulgarianHeritage/
├── Controllers/     # The brains of the operation
├── Models/         # Data structures and business logic
├── Views/          # All the HTML/Razor templates
├── Data/           # Database context and configuration
├── wwwroot/        # CSS, JavaScript, images, etc.
└── Migrations/     # Database schema changes
```

## What's Inside 🎪

The app includes information about different types of heritage sites:
- ⛪ **Churches & Monasteries** - Bulgaria's spiritual heritage
- 🏰 **Fortresses & Castles** - Medieval defensive structures  
- 🏺 **Archaeological Sites** - Ancient ruins and artifacts
- 🏘️ **Historical Towns** - Well-preserved old settlements
- 🌲 **Natural Heritage** - Protected landscapes and parks
- 🎭 **Cultural Sites** - Museums, theaters, and cultural centers

## Having Issues? 🛠️

If something's not working:

1. **App won't start?** Check if port 5001 is already being used
2. **Database problems?** Make sure SQL Server container is running: `docker ps`
3. **Weird errors?** Try resetting everything: `docker-compose down -v` then start over

## Want to Contribute? 🤝

Found a bug? Have an idea for a new feature? Want to add more heritage sites? 

1. Fork this repo
2. Create a new branch for your changes
3. Make your improvements
4. Test everything works
5. Send me a pull request!

I'm always open to collaboration and would love to see this project grow.

## A Personal Note 💭

This project means a lot to me personally. Bulgaria has such an incredible cultural heritage that often doesn't get the attention it deserves on the international stage. Through this app, I hope to help more people discover the amazing history and culture that Bulgaria has to offer.

If you use this project to plan a trip to Bulgaria or learn something new about Bulgarian heritage, I'd love to hear about it!

## License & Stuff 📄

This project is open source under the MIT License. Feel free to use it, modify it, or learn from it.

## Get in Touch 📧

Got questions? Want to chat about Bulgarian culture or web development? Feel free to open an issue or reach out!

---

*Made with ❤️ for Bulgarian heritage and web development* 