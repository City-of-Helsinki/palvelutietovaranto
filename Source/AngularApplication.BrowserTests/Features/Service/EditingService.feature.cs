﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ServiceRegister.AngularApplication.BrowserTests.Features.Service
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class EditingServiceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EditingService.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EditingService", "", ProgrammingLanguage.CSharp, new string[] {
                        "BrowserTest"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "EditingService")))
            {
                ServiceRegister.AngularApplication.BrowserTests.Features.Service.EditingServiceFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("the administrator user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("an organization exists with the name \'Daycare Inc.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions",
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table1.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon",
                        "Asuminen, Asumisen tuet",
                        "työväenopisto, päivähoito",
                        "Kansalaiset, Ikäihmiset",
                        "Asevelvollisuus, Muuttaminen",
                        "Palvelu, Kunta"});
#line 7
 testRunner.And("a service exists for the organization with following details", ((string)(null)), table1, "And ");
#line 10
 testRunner.And("organization services page is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Service basic information is shown correctly in read mode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ServiceBasicInformationIsShownCorrectlyInReadMode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Service basic information is shown correctly in read mode", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 13
 testRunner.When("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table2.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon"});
#line 14
 testRunner.Then("following service information is displayed", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Service basic information is shown correctly in edit mode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ServiceBasicInformationIsShownCorrectlyInEditMode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Service basic information is shown correctly in edit mode", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 19
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.When("the basic information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table3.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon"});
#line 21
 testRunner.Then("following service information is displayed in edit mode", ((string)(null)), table3, "Then ");
#line 24
 testRunner.And("save button is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Existing service basic information can be edited and edited information is shown " +
            "correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ExistingServiceBasicInformationCanBeEditedAndEditedInformationIsShownCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing service basic information can be edited and edited information is shown " +
                    "correctly", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 27
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("the basic information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table4.AddRow(new string[] {
                        "Daycare",
                        "Daycare for all children",
                        "Private daycare for all children",
                        "Daycare to assist public daycare",
                        "suomi",
                        "",
                        ""});
#line 29
 testRunner.When("The following information is edited", ((string)(null)), table4, "When ");
#line 32
 testRunner.And("the service information is saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table5.AddRow(new string[] {
                        "Daycare",
                        "Daycare for all children",
                        "Private daycare for all children",
                        "Daycare to assist public daycare",
                        "suomi",
                        "",
                        ""});
#line 33
 testRunner.Then("following service information is displayed", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Service languages can be edityed and edited information is shown correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ServiceLanguagesCanBeEdityedAndEditedInformationIsShownCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Service languages can be edityed and edited information is shown correctly", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 39
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("the basic information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("service language \'englanti\' is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("the service information is saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table6.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi, englanti",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon"});
#line 43
 testRunner.Then("following service information is displayed", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Service classification information is shown correctly in read mode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ServiceClassificationInformationIsShownCorrectlyInReadMode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Service classification information is shown correctly in read mode", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 48
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table7.AddRow(new string[] {
                        "Asuminen, Asumisen tuet",
                        "työväenopisto, päivähoito",
                        "Kansalaiset, Ikäihmiset",
                        "Asevelvollisuus, Muuttaminen",
                        "Kunta, Palvelu"});
#line 49
 testRunner.Then("following service classification information is displayed", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Service classification information is shown correctly in edit mode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ServiceClassificationInformationIsShownCorrectlyInEditMode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Service classification information is shown correctly in edit mode", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 54
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And("the classification information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table8.AddRow(new string[] {
                        "Asuminen, Asumisen tuet",
                        "työväenopisto, päivähoito",
                        "Kansalaiset, Ikäihmiset",
                        "Asevelvollisuus, Muuttaminen",
                        "Kunta, Palvelu"});
#line 56
 testRunner.Then("following service classification information is displayed in edit mode", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Existing service classification information can be edited and edited information " +
            "is shown correctly")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void ExistingServiceClassificationInformationCanBeEditedAndEditedInformationIsShownCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing service classification information can be edited and edited information " +
                    "is shown correctly", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 61
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And("the classification information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("service keywords are cleared", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.And("service class \'Asumisen tuet\' is removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("ontology term \'päivähoito\' is removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("target group \'Ikäihmiset\' is removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("life event \'Asevelvollisuus\' is removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("the service classification information is saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table9.AddRow(new string[] {
                        "Asuminen",
                        "työväenopisto",
                        "Kansalaiset",
                        "Muuttaminen",
                        ""});
#line 69
 testRunner.Then("following service classification information is displayed", ((string)(null)), table9, "Then ");
#line 72
 testRunner.And("service has no service class \'Asumisen tuet\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("service has no ontology term \'päivähoito\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("service has no target group \'Ikäihmiset\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("service has no life event \'Asevelvollisuus\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cancelling the editing of service basic information changes nothing")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void CancellingTheEditingOfServiceBasicInformationChangesNothing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancelling the editing of service basic information changes nothing", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 78
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.And("the basic information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.When("basic information editing is cancelled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table10.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon"});
#line 81
 testRunner.Then("following service information is displayed", ((string)(null)), table10, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table11.AddRow(new string[] {
                        "Asuminen, Asumisen tuet",
                        "työväenopisto, päivähoito",
                        "Kansalaiset, Ikäihmiset",
                        "Asevelvollisuus, Muuttaminen",
                        "Kunta, Palvelu"});
#line 84
 testRunner.And("following service classification information is displayed", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cancelling the editing of service classification information changes nothing")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EditingService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BrowserTest")]
        public virtual void CancellingTheEditingOfServiceClassificationInformationChangesNothing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancelling the editing of service classification information changes nothing", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 89
 testRunner.Given("the service \'Daycare\' is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.And("the classification information is put in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.When("classification information editing is cancelled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service name",
                        "Alternate name",
                        "Short description",
                        "Description",
                        "Languages",
                        "Requirements",
                        "User instructions"});
            table12.AddRow(new string[] {
                        "Daycare",
                        "Daycare for children",
                        "Private daycare",
                        "Daycare to help public daycare",
                        "suomi, ruotsi",
                        "User must have kids",
                        "Bring kids in the morning, take home in the afternoon"});
#line 92
 testRunner.Then("following service information is displayed", ((string)(null)), table12, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Service classes",
                        "Ontology terms",
                        "Target groups",
                        "Life events",
                        "Keywords"});
            table13.AddRow(new string[] {
                        "Asuminen, Asumisen tuet",
                        "työväenopisto, päivähoito",
                        "Kansalaiset, Ikäihmiset",
                        "Asevelvollisuus, Muuttaminen",
                        "Kunta, Palvelu"});
#line 95
 testRunner.And("following service classification information is displayed", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
