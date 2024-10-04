using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("name");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_GetsValueOfName_String()
    {
      string name = "artist name";
      Artist newArtist = new Artist(name);
      string result = newArtist.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetsValueOfName_String()
    {
      string name = "artist name";
      Artist newArtist = new Artist(name);
      string newName = "updated name";
      newArtist.Name = newName;
      string result = newArtist.Name;
      Assert.AreEqual(newName, result);
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      string name = "artist name";
      Artist newArtist = new Artist(name);
      int result = newArtist.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      Artist newArtist1 = new Artist("title 1");
      Artist newArtist2 = new Artist("title 2");
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

      List<Artist> result = Artist.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
  }
}