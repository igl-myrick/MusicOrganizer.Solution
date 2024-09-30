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
      Record newRecord = new Record();
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    public void GetTitle_GetsValueOfTitle_String()
    {
      Record newRecord = new Record();
      string title = newRecord.Title;
      Assert.AreEqual(title, newRecord.Title);
    }

    public void SetTitle_SetsValueOfTitle_String()
    {
      Record newRecord = new Record();
      string newTitle = "new title";
      newRecord.Title = newTitle;
      Assert.AreEqual(newTitle, newRecord.Title);
    }
  }
}