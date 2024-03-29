using ManagementService.Types;

namespace ManagementService.Models;

public class Medicine
{
  public Medicine(string tradeName, string concentration, string barCode, MedicineType medicineType)
  {
    Name = $"{tradeName} {concentration}";
    BarCode = barCode;
    MedicineType = medicineType;
  }

  public Medicine(string name, string barCode, MedicineType medicineType)
  {
    Name = name;
    BarCode = barCode;
    MedicineType = medicineType;
  }

  public string Name { get; set; }
  public string BarCode { get; set; }
  public MedicineType MedicineType { get; set; }
}
