# 🐾 Ultimate Tamagotchi

**Ultimate Tamagotchi** is an interactive virtual pet game developed in **C# for the console**. Inspired by the classic games of the 90s, this project goes a step further by offering a fully functional inventory management system, dynamic emotional states, multiple item types (with special effects), and a highly polished console interface featuring ASCII art.

## ✨ Main Features

### 1. 🐶 Choose and Customize Your Pet
* **Multiple Species:** You can choose between different types of pets at the start (Cat, Dog, or Chick), each instantiated from its own unique class.
* **Customization:** Give your pet a unique name (includes maximum character length validation).

### 2. 📊 Dynamic Stat System
Your pet has needs that must be carefully managed to keep it alive and happy:
* **Hunger, Energy, and Health:** Visually represented in the console using custom colored progress bars (`[#####-----]`).
* **Nutritional State:** An internal system that penalizes the abuse of snacks over full, healthy meals.
* **Emotional States:** The pet changes its facial expression (ASCII Art) based on its current state: Happy `^‿^`, Sad `╥﹏╥`, Angry `ಠ_ಠ`, Asleep `-_- zZ`, or Dead `x_x`.

### 3. 🎒 Inventory System & RNG (Loot)
The game features a limited inventory (up to 13 slots) that is fully functional:
* **Exploration (Find Item):** The player can search for items, which are generated using a probability system (RNG). Some items are common, while others are extremely rare (e.g., *Devil Fruit* or *Rokakaka*).
* **Management:** Ability to view the inventory, use items, and discard (throw away) those you no longer need to free up space.

### 4. 🍎 Item Types and Effects
The architecture allows for a wide variety of items, divided into categories:
* **Food:** * *Meals:* Restore a lot of hunger and improve nutritional state.
  * *Snacks:* Restore less hunger and worsen the nutritional state over time.
  * *Poison:* Dangerous items (like *Fentanyl* or *Mr Clean*) that can kill the pet.
* **Toys:** Consume energy and hunger, but make the pet very happy.
* **Special:** Magical items that can completely restore stats, alter the emotional state (make them happy, sad, or angry), or even **revive** a dead pet.

### 5. 🎮 Player Actions
The main game loop allows you to choose between several actions via a numerical menu:
1. Feed (using the inventory).
2. Put to sleep (restores energy, consumes hunger).
3. Play (using toys from the inventory).
4. Use special items.
5. Search for new items (RNG Loot).
6. Throw away inventory items.
7. Exit the game.

## 🛠️ Technical Aspects & Architecture
* **Separation of Concerns (Clean Architecture):** The project is highly modularized. 
  * `Program.cs`: The main game loop.
  * `UIManager.cs`: All console drawing logic, colors, and ASCII art.
  * `SelectionManager.cs` / `CheckManager.cs`: User input controllers and validations to prevent errors.
  * `ItemManager.cs`: Factory and instantiation of the game's entire item directory, including spawn chances.
  * `UIConfig.cs`: A constants file to centralize text strings, game variables, and configurations, making future translations or balancing much easier.
* **Object-Oriented Programming (OOP):** Heavy use of Inheritance (classes for each pet), Polymorphism, and Interfaces (`IEat`, `IPlay`, `ISleep`) to safely define what each entity can do.

---

## 🚀 Installation & How to Play

This project is developed using **C#** and the **.NET 10.0** framework. To run it on your machine, you have two main options:

### Prerequisites
* Have the [.NET 10.0 SDK](https://dotnet.microsoft.com/download) (or higher) installed.
* A code editor like **Visual Studio 2022**, **JetBrains Rider**, or **Visual Studio Code**.

### Option A: Run from Visual Studio
1. Download or clone this repository to your computer.
2. Open the solution file `Ultimate Tamagochi.slnx` with Visual Studio.
3. Ensure the main project (`Ultimate Tamagochi`) is set as the **Startup Project**.
4. Press the **"Run"** button (or the `F5` key) to compile and start the game in the console.

### Option B: Run from the Terminal (Command Line)
If you prefer using the terminal or don't have the full Visual Studio IDE:
1. Open your terminal (CMD, PowerShell, or Bash).
2. Navigate to the folder where the `Ultimate Tamagochi.csproj` file is located:
   ```bash
   cd path/to/your/project/Ultimate Tamagochi

   //Run the following command to automatically compile and launch the game:
   
    dotnet run

💡 Gameplay Tips

    Use Full Screen: When the console opens, it is recommended to maximize the window so the ASCII art of your pet and the UI align perfectly.

    Watch the Stats: If Hunger or Energy drops to zero, your pet's Health will start to decrease.

    Careful what you eat: Not all items you find will be good for your pet... Some could have fatal consequences!
