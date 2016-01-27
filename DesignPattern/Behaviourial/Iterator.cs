using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
	public class MedicalEquipment
	{
		public string FriendlyName { get; private set; }
		public string Product { get; private set; }
		public string Manufacturer { get; private set; }
		public string Model { get; private set; }
		public string Version { get; private set; }
		public long SerialNumber { get; private set; }
		public long CatalogueNumber { get; private set; }

		public MedicalEquipment(string name, string product, string manufacturer, string model, string version, long serialNumber, long catalogueNumber)
		{
			this.FriendlyName = name;
			this.Product = product;
			this.Manufacturer = manufacturer;
			this.Model = model;
			this.Version = version;
			this.SerialNumber = serialNumber;
			this.CatalogueNumber = catalogueNumber;
		}

		public override string ToString()
		{
			string assetDescription = $"{this.FriendlyName}: [Product: {this.Product}, Manufacturer: {this.Manufacturer}, Model: {this.Model}, Version: {this.Version}, Serial Number: {this.SerialNumber}, Catalogue Number: {this.CatalogueNumber}";
			return assetDescription;
		}
	}

	public class MedicalEquipmentCollection : IEnumerable<MedicalEquipment>, IDisposable
	{
		private Dictionary<string, List<MedicalEquipment>> _assetCollectionPerHospital = new Dictionary<string, List<MedicalEquipment>>();

		#region IEnumerable<Asset> Members

		public IEnumerator<MedicalEquipment> GetEnumerator()
		{
			foreach (string hospitalName in _assetCollectionPerHospital.Keys)
			{
				foreach (MedicalEquipment asset in _assetCollectionPerHospital[hospitalName])
				{
					yield return asset;
				}
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (IEnumerator)GetEnumerator();
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

		#region IDisposable Members

		public void Dispose()
		{
			_assetCollectionPerHospital = null;
		}

		#endregion
	}

	public class IteratorProgram
	{
		public static void RunIterator()
		{
			using (MedicalEquipmentCollection assetCollection = new MedicalEquipmentCollection())
			{
				assetCollection.AddAsset("Manipal Hospital", new MedicalEquipment("CV1_Manipal", "Cadio Vascular (CV)", "Philips", "2012", "3.5", 110928, 123456789));
				assetCollection.AddAsset("Manipal Hospital", new MedicalEquipment("XRAY1_Manipal", "XRAY", "Philips", "2011", "1.0", 110951, 987654321));

				assetCollection.AddAsset("Fortis", new MedicalEquipment("CT1_Fortis", "Computer Tomography (CT)", "Philips", "2010", "2.0", 110934, 123456789));
				assetCollection.AddAsset("Fortis", new MedicalEquipment("MR1_Fortis", "Mangetic Resonance (MR)", "Philips", "2012", "4.0", 123892, 182789252));

				foreach (MedicalEquipment asset in assetCollection)
				{
					Console.WriteLine(asset.ToString());
				}
			}
		}
	}
}
