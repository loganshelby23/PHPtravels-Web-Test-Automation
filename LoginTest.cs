// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class LoginTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  public string waitForWindow(int timeout) {
    try {
      Thread.Sleep(timeout);
    } catch(Exception e) {
      Console.WriteLine("{0} Exception caught.", e);
    }
    var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
    var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
    if (whNow.Count > whThen.Count) {
      return whNow.Except(whThen).First().ToString();
    } else {
      return whNow.First().ToString();
    }
  }
  [Test]
  public void login() {
    driver.Navigate().GoToUrl("https://phptravels.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
    vars["WindowHandles"] = driver.WindowHandles;
    driver.FindElement(By.XPath("//a[contains(text(),\'Log in\')]")).Click();
    vars["win8778"] = waitForWindow(2000);
    driver.SwitchTo().Window(vars["win8778"].ToString());
    driver.FindElement(By.Id("inputEmail")).SendKeys("user@");
    driver.FindElement(By.Id("inputEmail")).Click();
    driver.FindElement(By.Id("inputEmail")).SendKeys("user@phptravels.com");
    driver.FindElement(By.Id("inputPassword")).Click();
    driver.FindElement(By.Id("inputPassword")).SendKeys("demouser");
    driver.SwitchTo().Frame(0);
    driver.FindElement(By.CssSelector(".recaptcha-checkbox-border")).Click();
    driver.SwitchTo().DefaultContent();
    driver.FindElement(By.Id("login")).Click();
    Assert.That(driver.FindElement(By.CssSelector("small")).Text, Is.EqualTo("This page is restricted"));
  }
}
