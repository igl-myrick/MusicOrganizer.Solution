using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests
  {
    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("title");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    public void GetTitle_GetsValueOfTitle_String()
    {
      string title = "title";
      Record newRecord = new Record(title);
      Assert.AreEqual(title, newRecord.Title);
    }

    public void SetTitle_SetsValueOfTitle_String()
    {
      string title = "title";
      Record newRecord = new Record(title);
      string newTitle = "new title";
      newRecord.Title = newTitle;
      string result = newRecord.Title;
      Assert.AreEqual(newTitle, result);
    }

    public void GetAll_ReturnsRecords_RecordList()
    {
      Record newRecord1 = new Record("Title 1");
      Record newRecord2 = new Record("Title 2");
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
  }
}