using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Record.ClearAll();
    }

    public RecordTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }
    
    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("title");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetTitle_GetsValueOfTitle_String()
    {
      string title = "title";
      Record newRecord = new Record(title);
      Assert.AreEqual(title, newRecord.Title);
    }

    [TestMethod]
    public void SetTitle_SetsValueOfTitle_String()
    {
      string title = "title";
      Record newRecord = new Record(title);
      string newTitle = "new title";
      newRecord.Title = newTitle;
      string result = newRecord.Title;
      Assert.AreEqual(newTitle, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      Record newRecord1 = new Record("Title 1");
      newRecord1.Save();
      Record newRecord2 = new Record("Title 2");
      newRecord2.Save();
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "title";
      Record newRecord = new Record(title);
      int result = newRecord.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRecord_Record()
    {
      Record newRecord1 = new Record("Title 1");
      newRecord1.Save();
      Record newRecord2 = new Record("Title 2");
      newRecord2.Save();
      
      Record result = Record.Find(2);
      Assert.AreEqual(newRecord2, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_RecordList()
    {
      Record testRecord = new Record("title");
      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record> {testRecord};
      CollectionAssert.AreEqual(testRecord, result);
    }
  }
}