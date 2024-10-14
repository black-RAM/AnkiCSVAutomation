using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Runtime.InteropServices;

// Set up the Appium options
var appiumOptions = new AppiumOptions();
// I doubt that this is the Package Family Name
// That's what causes the error saying I should "specify [the] app".
// From the README.md of the Anki Universal Github repo,
// It says: you will need to add a Package.appxmanifest file into AnkiU solution
// So, I suppose I need to figure that out.
appiumOptions.AddAdditionalAppiumOption("Application", "Anki Universal");

// Connect to WinAppDriver
using var session = new WindowsDriver(new Uri("http://127.0.0.1:4723"), appiumOptions);
session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

// Automation script
// Navigate to adding notes in app
var addDeckButton = session.FindElement(By.Name("Add Deck"));
addDeckButton.Click();

var deckNameInput = session.FindElement(By.Name("Deck Name"));
deckNameInput.SendKeys("French");

var OK = session.FindElement(By.Name("OK"));
OK.Click();

var deckMenu = session.FindElement(By.Name("Deck Menu"));
deckMenu.Click();

var addNotes = session.FindElement(By.Name("Add Notes"));
addNotes.Click();

// Quit the session when done
session.Quit();

// Note: before running, open terminal and run:
// C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe