using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
  public class MedicalEquipment
  {
    public MedicalEquipment(string name, string product, string manufacturer, string model, string version,
      long serialNumber, long catalogueNumber)
    {
      FriendlyName = name;
      Product = product;
      Manufacturer = manufacturer;
      Model = model;
      Version = version;
      SerialNumber = serialNumber;
      CatalogueNumber = catalogueNumber;
    }

    public string FriendlyName { get; }
    public string Product { get; }
    public string Manufacturer { get; }
    public string Model { get; }
    public string Version { get; }
    public long SerialNumber { get; }
    public long CatalogueNumber { get; }

    public override string ToString()
    {
      string assetDescription =
        $"{FriendlyName}: [Product: {Product}, Manufacturer: {Manufacturer}, Model: {Model}, Version: {Version}, Serial Number: {SerialNumber}, Catalogue Number: {CatalogueNumber}";
      return assetDescription;
    }
  }

  public class MedicalEquipmentCollection : IEnumerable<MedicalEquipment>, IDisposable
  {
    private Dictionary<string, List<MedicalEquipment>> _assetCollectionPerHospital =
      new Dictionary<string, List<MedicalEquipment>>();

    #region IDisposable Members

    public void Dispose()
    {
      _assetCollectionPerHospital = null;
    }

    #endregion

    #region IEnumerable<Asset> Members

    public IEnumerator<MedicalEquipment> GetEnumerator()
    {
      foreach (var hospitalName in _assetCollectionPerHospital.Keys)
        foreach (var asset in _assetCollectionPerHospital[hospitalName])
          yield return asset;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    #endregion

    #region Public Members

    public List<MedicalEquipment> this[string hospital]
    {
      get { return _assetCollectionPerHospital[hospital]; }
    }

    public void AddAsset(string hospitalName, MedicalEquipment newAsset)
    {
      List<MedicalEquipment> assetCol;
      if (!_assetCollectionPerHospital.TryGetValue(hospitalName, out assetCol))
      {
        assetCol = new List<MedicalEquipment>();
        _assetCollectionPerHospital.Add(hospitalName, assetCol);
      }
      assetCol.Add(newAsset);
    }

    public void ClearAssets()
    {
      _assetCollectionPerHospital.Clear();
    }

    public int Count
    {
      get { return _assetCollectionPerHospital.Count; }
    }

    #endregion
  }

  public class IteratorProgram
  {
    public static void RunIterator()
    {
      using (var assetCollection = new MedicalEquipmentCollection())
      {
        assetCollection.AddAsset("Manipal Hospital",
          new MedicalEquipment("CV1_Manipal", "Cadio Vascular (CV)", "Philips", "2012", "3.5", 110928, 123456789));
        assetCollection.AddAsset("Manipal Hospital",
          new MedicalEquipment("XRAY1_Manipal", "XRAY", "Philips", "2011", "1.0", 110951, 987654321));

        assetCollection.AddAsset("Fortis",
          new MedicalEquipment("CT1_Fortis", "Computer Tomography (CT)", "Philips", "2010", "2.0", 110934, 123456789));
        assetCollection.AddAsset("Fortis",
          new MedicalEquipment("MR1_Fortis", "Mangetic Resonance (MR)", "Philips", "2012", "4.0", 123892, 182789252));

        foreach (var asset in assetCollection)
          Console.WriteLine(asset.ToString());
      }
    }
  }
}